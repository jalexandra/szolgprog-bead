import {Controller, send} from "../core/controller.abstract";
import {adminMiddleware} from "../middlewares/admin.middleware";
import {selfOrAdminMiddleware} from "../middlewares/self-or-admin.middleware";
import {Request, Response} from "express";
import {php} from "../core/php";
import {IUser} from "../models/user.interface";

export class UserController extends Controller{
    get path() {
        return 'users'
    }

    routes() {
        this.get(this.read, ':id', selfOrAdminMiddleware)
        this.get(this.browse, '', adminMiddleware)
        this.patch(this.edit, ':id', selfOrAdminMiddleware)
        this.delete(this.destroy, ':id', selfOrAdminMiddleware)
    }

    async browse(req: Request, res: Response) {
        const users = await php<IUser[]>('get')
        send(res, users)
    }

    async read(req: Request, res: Response) {
        const user = await php<IUser>('get', req.params.id)
        send(res, user)
    }

    async edit(req: Request, res: Response) {
        const id = req.params?.id

        await php<IUser>('patch', id, req.body)
        send(res, null, 204)
    }

    async destroy(req: Request, res: Response) {
        const id = req.params?.id

        await php<IUser>('delete', id)
        send(res, null, 204)
    }
}
