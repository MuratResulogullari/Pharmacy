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
    status: typeof(parseInt(status))==typeof(Number)? parseInt(status):0,
    languageId: typeof(parseInt(language))==typeof(Number)? parseInt(language):0,
    enable: Boolean(enable),
    sortOrder: typeof(parseInt(sortOrder))==typeof(Number)? parseInt(sortOrder):1
  };
  if (validation(pharmacyDto)) {
    this.pharmacyService.createPharmacy(pharmacyDto,()=>{
    
    },errorMessage=>{
      alert(errorMessage);
    });
  }
  
}

}
function validation(dto:PharmacyDTO) {
  if(dto.name==null || dto.name =="" || dto.name=='undefined')
  {
    alert("Name should be not empty.");
    return false;
  } else if(dto.phoneNumber==null || dto.phoneNumber =="" || dto.phoneNumber=='undefined')
  {
    alert("Phone should be not empty.");
    return false;
  } else if(dto.email==null || dto.email =="" || dto.email=='undefined')
  {
    alert("Email should be not empty.");
    return false;
  }
  else if(dto.address==null || dto.address =="" || dto.address=='undefined')
  {
    alert("Address should be not empty.");
    return false;
  }
  else if(dto.status==null || dto.status<0)
  {
    alert("Status should be not empty.");
    return false;
  }
  else if(dto.languageId==null || dto.languageId<0)
  {
    alert("Language should be not empty.");
    return false;
  }
  else if(dto.enable==null)
  {
    alert("Language should be not empty.");
    return false;
  }
  else if(dto.sortOrder==null || dto.sortOrder<0)
  {
    alert("Sort order should be not empty.");
    return false;
  }
  return true;
}