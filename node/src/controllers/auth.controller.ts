import {abort, Controller, send} from "../core/controller.abstract";
import {Execute, Find, FindAll} from "../core/sql";
import {IUser} from "../models/user.interface";
import {Request, Response} from "express";
import {randomBytes} from "crypto";
import {compare, genSalt, hash} from "bcrypt";
import App from "../core/app";
import {IBook} from "../models/book.interface";
import {forEach} from "../core/await.wrapper";
import {IAuthor} from "../models/author.interface";
import {userMiddleware} from "../middlewares/user.middleware";

export class AuthController extends Controller {
    get path() {
        return '/auth'
    }

    routes() {
        this.post(this.login, 'login')
        this.post(this.register, 'register')
        this.get(this.profile, 'profile', userMiddleware)
    }

    async login(req: Request, res: Response) {
        const {email, password} = req.body
        if(!(email && password))
            return abort(res, 400, 'Email and password are required')

        const user = await Find<IUser>(`SELECT * FROM users WHERE email = ?`, email)
        if (!user) return abort(res, 401)

        const valid = await compare(password, user.password!)
        if (!valid) return abort(res, 403)

        const token = generateToken()
        await Execute('UPDATE users SET api_key = ? WHERE id = ?', token, user.id)
        return res.json({token})
    }

    async register(req: Request, res: Response) {
        const email = req.body?.email
        if (!email) return abort(res, 400, 'Email is required')

        const user = await Find<IUser>(`SELECT *
                                        FROM users
                                        WHERE email = ?`, email)
        if (user) return abort(res, 400, 'Email already exists')

        const password = req.body?.password
        if (!password) return abort(res, 400, 'Password is required')

        const name = req.body?.name
        if (!name) return abort(res, 400, 'Name is required')

        const token = generateToken();
        await Execute(
            'INSERT INTO users (name, email, password, api_key) VALUES (?, ?, ?, ?)',
            name, email, await generatePassword(password), token
        )
        return send(res, {token}, 201)
    }

    async profile(req: Request, res: Response) {
        const user = await Find<IUser>(`SELECT name, email, phone, created_at FROM users WHERE id = ?`, App.user?.id)
        if (!user) return abort(res, 404)

        user.rented_books = await FindAll<IBook[]>('SELECT * FROM books WHERE rented_by = ?', App.user?.id)
        await forEach(user.rented_books).do(book =>
            FindAll<IAuthor[]>(
                `SELECT * 
                     FROM authors 
                    WHERE id IN (
                        SELECT author_id 
                        FROM authors_books 
                        WHERE book_id = ?
                    )`,
                book.id
            )
        )
        return send(res, user)
    }
}

function generateToken() {
    return randomBytes(16).toString('hex')
}

async function generatePassword(clean: string) {
    return hash(clean, await genSalt(10))
}
