import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { PharmacyDTO } from 'src/app/contracts/pharmacy/pharmacy-dto';
import { HttpResponse } from '@angular/common/http';
import { RequestResult } from 'src/app/contracts/base/request-result';


@Injectable({
  providedIn: 'root'
})
export class PharmacyService {

  constructor(private httpClientService: HttpClientService) { }

  createPharmcy(pharmacyDto:PharmacyDTO){
    this.httpClientService.post({
      controller:"pharmacy",
      action:"CreatePharmacy"
    },pharmacyDto).subscribe((response: RequestResult<PharmacyDTO>) => {
      if (response.success) {
        console.info(response.message);
      }else{
      console.error(response.message);
      }
      alert(response.message);
    });
  }
  updatePharmcy(pharmacy:PharmacyDTO){
    
  }
  deletePharmcy(id:number){
    
  }
  getPharmcyById(id:number){
    this.httpClientService.get<RequestResult<PharmacyDTO>>({
      controller:"pharmacy",
      action:"getPharmacyById",
    },id).subscribe(response=> console.log(response.result?.name));
  }
 
}
