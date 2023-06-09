import { Component, OnInit } from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { PagedCriteriaObject } from 'src/app/contracts/criteria/base/paged-criteria-object';
import { PharmacyDTO } from 'src/app/contracts/pharmacy/pharmacy-dto';
import { PharmacyService } from 'src/app/services/common/pharmacyservices/pharmacy.service';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
 
})
export class ListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'phoneNumber', 'email','status','languageId','enable','sortOrder','actions'];
  dataSource = new MatTableDataSource<PharmacyDTO>();
  items=new Array<PharmacyDTO>();
 constructor(private pharmacyService : PharmacyService ){}
 ngOnInit(): void {
  this.getPagedList();
 }

 getPagedList(): void {
  const criteria: PagedCriteriaObject = new PagedCriteriaObject();
  criteria.currentPage = 1;
  criteria.recordsCountOfPerPage = 10;

  this.pharmacyService.getPharmacyPagedList(criteria)
    .then((d) => {
      if (d.success && d.result?.success && d.result.items != null) {
        this.dataSource = new MatTableDataSource<PharmacyDTO>(d.result.items);
        this.items=d.result.items? d.result.items: new Array<PharmacyDTO>();
      } else {
        this.dataSource = new MatTableDataSource<PharmacyDTO>([]);
        this.items=new Array<PharmacyDTO>();
      }
    })
    .catch((error) => {
      console.error('An error occurred while fetching pharmacy data:', error);
    });
}
onEdit(dto?:PharmacyDTO){
  if (dto !=null) {
    const pharmacyDto= this.items.filter(x=>x.id==dto?.id);
    this.openUpdateModal(dto);
  }
  
}
openUpdateModal(dto?:PharmacyDTO): void {
  
}

updatePharmacy(dto?:PharmacyDTO): void {
  if (dto !=null) {
   this.pharmacyService.updatePharmacy(dto,(response)=>{
     if (response.success) {
       alert(response.message);
       this.ngOnInit();
     }
   },(error)=>{
     console.error(error);
   }); 
  }
  else{
    alert("Selected should be not empty!");
  }
}
onDelete(dto?:PharmacyDTO){
  if (dto !=null) {
    this.deletePharmacy(dto.id);
  }

  
}
deletePharmacy(id?:number): void {
 
  if (id!=null) {
   this.pharmacyService.deletePharmacy(id,(response)=>{
     if (response.success) {
       alert(response.message);
       this.ngOnInit();
     }
   },(error)=>{
     console.error(error);
   }); 
  }
  else{
    alert("Selected should be not empty!");
  }
}
}
