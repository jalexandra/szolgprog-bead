import {NextFunction} from 'express'

export function loggerMiddleware(req: Request, res: Response, next: NextFunction) {
  next()
  // @ts-ignore
  console.log(`${req.method} ${req.url} ${res.statusCode}`)
}
