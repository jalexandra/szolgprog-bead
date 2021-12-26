import {NextFunction, Request, Response} from "express";
import {userMiddlewareLogic} from "./user.middleware";
import {IUser} from "../models/user.interface";

export async function adminMiddleware(req: Request, res: Response, next: NextFunction) {
    const user = await userMiddlewareLogic(req, res, next);

    if(!user || !(user as IUser).is_admin) {
        res.status(401).end();
        return false;
    }

    next();
}
