import { BaseDTO } from "../base/base-dto";

export class PharmacyDTO extends BaseDTO <number>{
    name?  :string;
    address?:string;
    phoneNumber?:string;
    email?:string;
    status?:number
   }