import {loggerMiddleware} from './middlewares/logger.middleware'
import bodyParser from 'body-parser'
import App from './core/app'
import {Controller} from './core/controller.abstract'
import {AuthorController} from './controllers/author.controller'
import * as dotenv from 'dotenv'
import mysql from 'mysql2'
import {BookController} from './controllers/book.controller'
import {UserController} from "./controllers/user.controller";
import {AuthController} from "./controllers/auth.controller";

dotenv.config()
export const db = mysql.createConnection({
    host: process.env.DB_HOST,
    user: process.env.DB_USER,
    password: process.env.DB_PWD,
    database: process.env.DB_NAME
});
const app = new App(3000, db)

const controllers: Controller[] = [
    new AuthController(),
    new AuthorController(),
    new BookController(),
    new UserController(),
]

const middlewares: any[] = [
    bodyParser.json(),
    bodyParser.urlencoded({ extended: true }),
    loggerMiddleware
]

app.init(controllers, middlewares).listen()
