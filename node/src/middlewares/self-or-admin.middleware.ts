import {NextFunction, Request, Response} from "express";
import {userMiddlewareLogic} from "./user.middleware";
import {send} from "../core/controller.abstract";

export async function selfOrAdminMiddleware(req: Request, res: Response, next: NextFunction) {
  const user = await userMiddlewareLogic(req, res, next)

  if (!(user?.is_admin || user?.id?.toString() === req.params?.id)) {
    send(res, null, 403)
    return false
  }

  next()
}
