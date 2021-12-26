import axios from "axios";
import {IUser} from "../models/user.interface";

export function php<TRes=any>(verb: string, id: string|null = null, body: any = null): Promise<TRes> {
    let uri = `http://localhost:8080/index.php?m=users&v=${verb}`
    if(id)
        uri += `&id=${id}`

    if(verb === 'get')
        return axios.get(uri)

    return axios.post(uri)
}
