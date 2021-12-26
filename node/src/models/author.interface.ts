import {IBook} from "./book.interface";
import {IResource} from "../core/resource.interface";

export interface IAuthor extends IResource{
    name: string
    books?: IBook[]
}
