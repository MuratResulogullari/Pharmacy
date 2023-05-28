import { HttpHeaders } from "@angular/common/http";

export class RequestPrameterCO{
    baseUrl?:string;
    controller?:string;
    action?:string;
    param?:string;
    headers?:HttpHeaders;
    endPoint?:string;
  }