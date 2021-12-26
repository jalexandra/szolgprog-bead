import express from 'express'
import {Controller} from './controller.abstract'
import {Middleware} from "./middleware.type";
import {IUser} from "../models/user.interface";
import {Connection} from "mysql2";

export default class App {
    static get instance(): App {
        return this._instance;
    }

    static get user(): IUser|null {
        return App.instance.user
    }

    static get sql(): Connection {
        return App.instance.sql
    }

    static get express(): express.Application {
        return App.instance.app
    }

    private static _instance: App

    private readonly app: express.Application
    private readonly user: IUser|null = null
    readonly router: express.Router

    constructor(
        public readonly port: number,
        public readonly sql: Connection
    ) {
        this.app = express()
        this.router = express.Router()

        App._instance = this
    }

    private initializeMiddlewares(middlewares: any[]) {
        for (const middleware of middlewares)
            this.app.use(middleware)
    }

    listen() {
        this.app.listen(this.port, () => console.log(`App listening on the port ${this.port}`))
        return this
    }

    init(controllers: Controller[], middlewares: Middleware[]) {
        this.initializeMiddlewares(middlewares)
        this.app.use(this.router)
        return this
    }
}
