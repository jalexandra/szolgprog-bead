import {IResource} from "../core/resource.interface";
import {IBook} from "./book.interface";

export interface IUser extends IResource {
    name: string
    email: string
    is_admin?: boolean
    password?: string
    password_confirmation?: string
    rented_books?: IBook[]
    api_key?: string
}
