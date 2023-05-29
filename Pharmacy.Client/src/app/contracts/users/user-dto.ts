import { RoleDTO } from "./role-dto";

export class UserDTO {
    id?: number;
    tckn?:string
    username?: string;
    password?: string;
    name?: string;
    surname?: string;
    token?: string;
    roles?:Array<RoleDTO>;
}
