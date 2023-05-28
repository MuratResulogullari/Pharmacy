import { Component, OnInit } from '@angular/core';
import { RequestResult } from 'src/app/contracts/base/request-result';
import { PharmacyDTO } from 'src/app/contracts/pharmacy/pharmacy-dto';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-pharmacies',
  templateUrl: './pharmacies.component.html',
  styleUrls: ['./pharmacies.component.css']
})
export class PharmaciesComponent  implements OnInit{
  constructor(private httpClientServe:HttpClientService){}
  ngOnInit(): void {
    this.httpClientServe.get<RequestResult<PharmacyDTO>>({
      controller:"pharmacy",
      action:"getPharmacyById",
    },2).subscribe(response=> console.log(response.result?.name));
      
     
      


    var dto= new PharmacyDTO();
    dto.languageId=1;
    dto.enable=true;
    dto.sortOrder=2;
    dto.name="Çam Eczanesi";
    dto.address="İzmir Karşıyaka";
    dto.phoneNumber="05345679723";
    dto.email="cam.eczanesi@gmaşl.com";
    dto.status=2;
    // this.httpClientServe.post({
    //   controller:"pharmacy",
    //   action:"CreatePharmacy"
    // },dto).subscribe(d=>console.log(d));
   
    //  this.httpClientServe.put({
    //   controller:"pharmacy",
    //   action:"UpdatePharmacy"
    // },dto).subscribe(d=>console.log(d));

    dto.id=2;

    //   this.httpClientServe.delete({
    //   controller:"pharmacy",
    //   action:"DeletePharmacy"
    // },dto,2).subscribe(d=>console.log(d));
  }
}
