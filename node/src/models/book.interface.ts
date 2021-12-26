import {IUser} from "./user.interface";
import {IResource} from "../core/resource.interface";
import {IAuthor} from "./author.interface";

export interface IBook extends IResource{
    title: string
    release_year: number
    authors?: IAuthor[]
    rented_by?: IUser
}
