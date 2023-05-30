import { Inject,Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http"
import { Observable } from 'rxjs';
import { RequestPrameterCO } from 'src/app/contracts/criteria/base/request-prameter-co';
import { RequestResult } from 'src/app/contracts/base/request-result';
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

  postGeneric<T>(requestPrameterCO:Partial<RequestPrameterCO>,body: Partial<T>):Observable<T> {
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}`;
    
    return this.httpClient.post<T>(url,body,{headers:requestPrameterCO.headers})
  }
  post(requestPrameterCO:Partial<RequestPrameterCO>,body:any){
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}`;
    
    return this.httpClient.post(url,body,{headers:requestPrameterCO.headers})
  }
 
  put(requestPrameterCO:Partial<RequestPrameterCO>,body:any) {
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}`;
    return this.httpClient.put(url,body,{headers:requestPrameterCO.headers})
  }
  putGeneric<T>(requestPrameterCO:Partial<RequestPrameterCO>,body: Partial<T>):Observable<T> {
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}`;
    return this.httpClient.put<T>(url,body,{headers:requestPrameterCO.headers})
  }
  delete(requestPrameterCO:Partial<RequestPrameterCO>,id?:number){
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}${id?`/${id}`:""}`;
    return this.httpClient.delete(url)
  }
  deleteGeneric<T>(requestPrameterCO:Partial<RequestPrameterCO>, body: Partial<T>,id?:number) :Observable<T> {
    let url :string="";
    url = requestPrameterCO.endPoint? requestPrameterCO.endPoint : `${this.url(requestPrameterCO)}${id?`/${id}`:""}`;
    return this.httpClient.delete<T>(url,body)
  }

}



