import {abort, Controller, send} from "../core/controller.abstract";
import {Request, Response} from "express";
import {adminMiddleware} from "../middlewares/admin.middleware";
import {Execute, Find, FindAll} from "../core/sql";
import {IAuthor} from "../models/author.interface";
import {IBook} from "../models/book.interface";
import {forEach} from "../core/await.wrapper";
import {selfOrAdminMiddleware} from "../middlewares/self-or-admin.middleware";

export class AuthorController extends Controller{
    get path() {
        return 'authors'
    }

    routes() {

        this.get(this.read, ':id')
        this.get(this.browse, '')
        this.patch(this.edit, ':id', adminMiddleware )
        this.post(this.add,'', adminMiddleware)
        this.delete(this.destroy, ':id', adminMiddleware)
    }

    async browse(req: Request, res: Response) {
        const authors = await FindAll<IAuthor[]>('SELECT * FROM authors ORDER BY name')

        await forEach(authors).do(author =>
            FindAll<IBook[]>(
            `SELECT * 
                 FROM books, authors_books 
                 WHERE authors_books.book_id = books.id 
                   AND authors_books.author_id = ?
                 ORDER BY books.title`,
            [author.id])
            .then(books => author.books = books)
        )

        return send(res, authors)
    }

    async read(req: Request, res: Response) {
        const id = req.params?.id

        const author = await Find<IAuthor>(`SELECT * FROM authors WHERE id = ?`, [id])
        if (!author) return abort(res, 404, 'Author not found')

        author.books = await FindAll<IBook[]>(
            `SELECT * 
                 FROM books, authors_books 
                 WHERE authors_books.book_id = books.id 
                   AND authors_books.author_id = ?
                 ORDER BY books.title`,
            [id]
        )

        return send(res, author)
    }

    async edit(req: Request, res: Response) {
        const id = req.params?.id

        const author = await Find<IAuthor>(`SELECT * FROM authors WHERE id = ?`, id)
        if (!author) return abort(res, 404, 'Author not found')

        const name = req.body?.name
        if (name)
            await Execute(`UPDATE authors SET name = ? WHERE id = ?`, name, id)

        const books: number[] = req.body?.books
        if (!books)
            return send(res, null, 204)

        await Execute(`DELETE FROM authors_books WHERE author_id = ?`, id)
        await forEach(books).do(book_id =>
            Execute(`INSERT INTO authors_books (author_id, book_id) VALUES (?, ?)`, id, book_id)
        )

        return send(res, null, 204)
    }

    async add(req: Request, res: Response) {
        const name = req.body?.name
        if (!name) return abort(res, 400, 'No name provided')

        await Execute(`INSERT INTO authors (name) VALUES (?)`, name)
        return send(res, null, 201)
    }

    async destroy(req: Request, res: Response) { // Note: delete is a reserved keyword
        const id = req.params?.id

        await Execute(`DELETE FROM authors WHERE id = ?`, id)

        return send(res, null, 204)
    }
}
