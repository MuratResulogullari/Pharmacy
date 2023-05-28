import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PharmacyDTO } from 'src/app/contracts/pharmacy/pharmacy-dto';
import { PharmacyService } from 'src/app/services/common/pharmcies/pharmacy.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
 constructor(private pharmacyService : PharmacyService){

 }
 ngOnInit(): void {
   
 }
 
 createPharmacy(name: string, phone: string, email: string, address: string,status:string,language:string,sortOrder: string, enable: string) {
  const pharmacyDto: PharmacyDTO = {
    name: name,
    phoneNumber: phone,
    email: email,
    address: address,
    status: parseInt(status),
    languageId: parseInt(language),
    enable: Boolean(enable),
    sortOrder: parseInt(sortOrder)
  };
  this.pharmacyService.createPharmcy(pharmacyDto);
}

}
