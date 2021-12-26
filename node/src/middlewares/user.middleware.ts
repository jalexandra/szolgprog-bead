import {NextFunction, Request, Response} from "express";
import {Find} from "../core/sql";
import {IUser} from "../models/user.interface";
import {send} from "../core/controller.abstract";

export async function userMiddleware(req: Request, res: Response, next: NextFunction) {
    if (!await userMiddlewareLogic(req, res, next))
        return null

    next();
}

export async function userMiddlewareLogic(req: Request, res: Response, next: NextFunction) {
    const apiKey = req.get('X-API-KEY')
    if(!apiKey) {
        res.status(401).end()
        return null
    }

    const user = await Find<IUser>('SELECT * FROM users WHERE api_key = ?', apiKey)
    if(!user) {
        send(res, null,401)
        return null
    }

    return user
}
