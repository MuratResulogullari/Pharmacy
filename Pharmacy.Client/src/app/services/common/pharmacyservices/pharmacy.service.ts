import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { PharmacyDTO } from 'src/app/contracts/pharmacy/pharmacy-dto';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { RequestResult } from 'src/app/contracts/base/request-result';
import { PagedResult } from 'src/app/contracts/base/paged-result';
import { PagedCriteriaObject } from 'src/app/contracts/criteria/base/paged-criteria-object';


@Injectable({
  providedIn: 'root'
})
export class PharmacyService {

  constructor(private httpClientService: HttpClientService) { }

  // createPharmcy(pharmacyDto:PharmacyDTO, successCallBack?:any , errorCallBack?: (errorMessage: any) => void){
  //   this.httpClientService.post({
  //     controller:"pharmacy",
  //     action:"CreatePharmacy"
  //   },pharmacyDto).subscribe((response) => {
  //     successCallBack();
  //   },(httpErrorResponse:HttpErrorResponse)=>{
  //     const _error :Array<{key:string,value:Array<string>}>=httpErrorResponse.error;// my specific get error respoonse for catch ValidetionFilter throw errors 
  //     let error ="";
  //     _error.forEach((v,index)=>{
  //         v.value.forEach((_v,index)=>{
  //         error+=`${_v}<br>`;
  //       });
  //     });
  //     errorCallBack(error);
  //   });
  // }
  
createPharmacy(pharmacyDto: PharmacyDTO, successCallBack?: (response:object) => void,errorCallBack?: (errorMessage: string) => void) {
  this.httpClientService.post({
    controller: "pharmacy",
    action: "CreatePharmacy"
  }, pharmacyDto).subscribe(
    (response) => {
      if (successCallBack) {
        successCallBack(response);
      }
    },
    (httpErrorResponse: HttpErrorResponse) => {
      let errorMessage = '';
      // const errorResponse: { key: string, value: string[] }[] = httpErrorResponse.error;
      const errorResponse :Array<{key:string,value:Array<string>}>=httpErrorResponse.error;// my specific get error respoonse for catch ValidetionFilter throw errors 
      
      if (errorResponse !=null ) {
        errorResponse.forEach((errorObj) => {
          const errorMessages = errorObj.value.join(' ');
          errorMessage += `${errorObj.key}: ${errorMessages} `;
        });
      }
      if (errorCallBack) {
        errorCallBack(errorMessage);
      }
    }
  );
}

  updatePharmacy(pharmacy:PharmacyDTO){
    
  }
  deletePharmacy(id:number ,successCallBack?: (response:RequestResult<object>) => void,errorCallBack?: (errorMessage: string) => void){
    return  this.httpClientService.delete({
          controller:"pharmacy",
          action:"deletePharmacy"
        }, id).subscribe(
          (response) => {
            if (successCallBack) {
              successCallBack(response);
            }
          },(err)=>{
            if(errorCallBack)
              errorCallBack(err)
          });
  }
  getPharmcyById(id:number){
    this.httpClientService.get<RequestResult<PharmacyDTO>>({
      controller:"pharmacy",
      action:"getPharmacyById",
    },id).subscribe(response=> console.log(response.result?.name));
  }
  async getPharmacyPagedList(criteria: PagedCriteriaObject, successCallBack?: () => void,errorCallBack?: (errorMessage: string) => void): Promise<RequestResult<PagedResult<PharmacyDTO>>> {
    try {
      const result: any = await this.httpClientService.post({
        controller: "pharmacy",
        action: "getPharmacyPagedList",
      },criteria).toPromise();
      
      return result;
    } catch (error) {
      // Handle error here
      console.error('An error occurred while fetching pharmacy data:', error);
      throw error;
    }
  }
}

