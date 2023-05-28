import { Component, OnInit } from '@angular/core';
import { HttpClientService, PharmaciesDTO, RequestResult } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-pharmacies',
  templateUrl: './pharmacies.component.html',
  styleUrls: ['./pharmacies.component.css']
})
export class PharmaciesComponent  implements OnInit{
  constructor(private httpClientServe:HttpClientService){}
  ngOnInit(): void {
    // this.httpClientServe.get({
    //   controller:"pharmacy",
    //   action:"getPharmacyById",
    // },1).subscribe(d=>console.log(d));
    var dto= new PharmaciesDTO();
  
    dto.LanguageId=1;
    dto.Enable=true;
    dto.SortOrder=2;
    dto.Name="Çam Eczanesi";
    dto.Address="İzmir Karşıyaka";
    dto.PhoneNumber="05345679723";
    dto.Email="cam.eczanesi@gmaşl.com";
    dto.Status=2;
    // this.httpClientServe.post({
    //   controller:"pharmacy",
    //   action:"CreatePharmacy"
    // },dto).subscribe(d=>console.log(d));
    dto.Id=2;
    //  this.httpClientServe.put({
    //   controller:"pharmacy",
    //   action:"UpdatePharmacy"
    // },dto).subscribe(d=>console.log(d));

      this.httpClientServe.delete({
      controller:"pharmacy",
      action:"DeletePharmacy"
    },dto,2).subscribe(d=>console.log(d));
  }
}
