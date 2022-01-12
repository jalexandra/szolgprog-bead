import {abort, Controller, send} from '../core/controller.abstract'
import {adminMiddleware} from '../middlewares/admin.middleware'
import {Request, Response} from 'express'
import {Execute, Find, FindAll} from '../core/sql'
import {IBook} from '../models/book.interface'
import {IAuthor} from '../models/author.interface'
import {forEach} from '../core/await.wrapper'

export class BookController extends Controller{

    get path(): string {
        return 'books'
    }

    routes(): void {
        this.get(this.read, ':id')
        this.get(this.browse,'')
        this.patch(this.edit, ':id', adminMiddleware)
        this.post(this.add, '', adminMiddleware)
        this.delete(this.destroy, ':id', adminMiddleware)
    }

    async read(req: Request, res: Response) {
        const id = req.params?.id

        const book = await Find<IBook>(`SELECT * FROM books WHERE id = ?`, [id])
        if (!book) return abort(res, 404, 'Book not found')

        book.authors = await FindAll<IAuthor[]>(
            `SELECT *
            FROM authors, authors_books
            WHERE authors_books.author_id = authors.id
            AND authors_books.book_id = ?
            ORDER BY authors.name`,
            [id]
        )
        return send(res, book)
    }

    async browse(req: Request, res: Response) {
        const books = await FindAll<IBook[]>('SELECT * FROM books ORDER BY title')

        await forEach(books).do(book =>
            FindAll<IAuthor[]>(
                `SELECT *
            FROM authors, authors_books
            WHERE authors_books.author_id = authors.id
            AND authors_books.book_id = ?
            ORDER BY authors.name`,
                [book.id])
                .then(authors => book.authors = authors)
        )
        return send(res, books)
    }

    async edit(req: Request, res: Response) {
        const id = req.params?.id

        const book = await Find<IBook>(`SELECT * FROM books WHERE id = ?`, id)
        if (!book) return abort(res, 404, 'Book not found')

        const title = req.body?.title
        if (title)
            await Execute(`UPDATE books SET title = ? WHERE id = ?`, title, id)

        const release_year = req.body?.release_year
        if (release_year)
            await Execute(`UPDATE books SET release_year = ? WHERE id = ?`, release_year, id)

        const authors: number[] = req.body?.authors
        if (authors) {
            await Execute(`DELETE FROM authors_books WHERE book_id = ?`, id)
            await forEach(authors).do(author_id =>
                Execute(`INSERT INTO authors_books (book_id, author_id) VALUES (?, ?)`, id, author_id)
            )
        }
        return send(res, null, 204)
    }

    async add(req: Request, res: Response) {
        const title = req.body?.title
        if (!title) return abort(res, 400, 'No title provided')

        const release_year = req.body?.release_year
        if (!release_year) return abort(res, 400, 'No year of release provided')

        const authors: number[] = req.body?.authors ?? []
        if(authors.length === 0) return abort(res, 400, 'No authors provided')

        let foundAllAuthor = true
        await forEach(authors).do(author_id =>
            Find<IAuthor>(`SELECT * FROM authors WHERE id = ?`, author_id)
                .then(author => {
                    if (!author) foundAllAuthor = false
                }))
        if (!foundAllAuthor) return abort(res, 400, 'One or more authors not found')

        await Execute(`INSERT INTO books (title, release_year) VALUES (?, ?)`, title, release_year)

        const book = await Find<IBook>(`SELECT * FROM books WHERE title = ? AND release_year = ?`, title, release_year)

        await forEach(authors).do(author_id =>
            Execute(`INSERT INTO authors_books (book_id, author_id) VALUES (?, ?)`, book.id, author_id)
        )
        return send(res, null, 201)
    }

    async destroy(req: Request, res: Response) {
        const id = req.params?.id

        await Execute('DELETE FROM books WHERE id = ?', id)

        return send(res, null, 204)
    }
}
