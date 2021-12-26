import express from 'express'
import {Middleware} from './middleware.type'
import App from "./app";

export abstract class Controller {

    abstract get path(): string
    abstract routes(): void

    constructor() {
        this.routes()
    }

    protected get(callback: (req: express.Request, res: express.Response) => void, pathExtension: string[]|string = [], ...middlewares: Middleware[]) {
        App.instance.router.get(this.buildUri(pathExtension), callback, ...(middlewares as any[]))
    }

    protected post(callback: (req: express.Request, res: express.Response) => void, pathExtension: string[]|string = [], ...middlewares: Middleware[]) {
        App.instance.router.post(this.buildUri(pathExtension), callback, ...(middlewares as any[]))
    }

    protected patch(callback: (req: express.Request, res: express.Response) => void, pathExtension: string[]|string = [], ...middlewares: Middleware[]) {
        App.instance.router.patch(this.buildUri(pathExtension), callback, ...(middlewares as any[]))
    }

    protected delete(callback: (req: express.Request, res: express.Response) => void, pathExtension: string[]|string = [], ...middlewares: Middleware[]) {
        App.instance.router.delete(this.buildUri(pathExtension), callback, ...(middlewares as any[]))
    }

    private buildUri(pathExtension: string[]|string) {
        let path = `/${this.path}`
        path += (
            (typeof pathExtension) === 'string'
                 ?  `/${pathExtension}`
                 : `/${(pathExtension as string[]).join('/')}`
        )
        return path
    }
}

export function send(res: express.Response, data: any, status: number = 200): true {
    res.send(data)
    res.end()
    return true
}

export function abort(res: express.Response, status: number, message: string|null = null): false {
    res.status(status).send(message ? { message } : { }).end()
    res.end()
    return false
}
