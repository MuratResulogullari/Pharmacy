import { Inject,Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http"
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private httpClient:HttpClient, @Inject("baseUrl") private baseUrl: string) {}
 
  private url(requestPrameterCO:Partial<RequestPrameterCO>) {
   return `${requestPrameterCO.baseUrl ? requestPrameterCO.baseUrl:this.baseUrl}/${requestPrameterCO.controller}${requestPrameterCO.action? `/${requestPrameterCO.action}`:""}`;
  }

  get<T>(requestPrameterCO:Partial<RequestPrameterCO>,id?:number): Observable<T>{
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}${id?`/${id}`:""}`;
    return this.httpClient.get<T>(url,{headers:requestPrameterCO.headers})
  }

  post<T>(requestPrameterCO:Partial<RequestPrameterCO>,body: Partial<T>):Observable<T> {
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}`;
    return this.httpClient.post<T>(url,body,{headers:requestPrameterCO.headers})
  }
 
  put<T>(requestPrameterCO:Partial<RequestPrameterCO>,body: Partial<T>):Observable<T> {
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}`;
    return this.httpClient.put<T>(url,body,{headers:requestPrameterCO.headers})
  }
  delete<T>(requestPrameterCO:Partial<RequestPrameterCO>, body: Partial<T>,id?:number) :Observable<T> {
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}${id?`/${id}`:""}`;
    return this.httpClient.delete<T>(url,body)
  }

}

export class RequestResult<TEntity>
    {
          Success?:boolean;
        Message?:string;
        Result?:TEntity;
        RedirectUrl?:string;
    }
export class RequestPrameterCO{
  baseUrl?:string;
  controller?:string;
  action?:string;
  param?:string;
  headers?:HttpHeaders;
  endPoint?:string;
}
export class BaseDTO<Tkey>{
  Id?:Tkey;
  LanguageId?:number;
  Enable?:boolean;
  SortOrder?:number;
}
export class PharmaciesDTO extends BaseDTO<number>{
  Name?:string;
  Address?:string;
  PhoneNumber?:string;
  Email?:string;
  Status?:number
 }