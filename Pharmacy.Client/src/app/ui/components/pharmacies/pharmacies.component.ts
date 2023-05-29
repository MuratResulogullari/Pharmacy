import { Component, OnInit } from '@angular/core';
import { PagedCriteriaObject } from 'src/app/contracts/criteria/base/paged-criteria-object';
import { PharmacyDTO } from 'src/app/contracts/pharmacy/pharmacy-dto';
import { PharmacyService } from 'src/app/services/common/pharmacyservices/pharmacy.service';

@Component({
  selector: 'app-pharmacies',
  templateUrl: './pharmacies.component.html',
  styleUrls: ['./pharmacies.component.css']
})
export class PharmaciesComponent implements OnInit {
  items: PharmacyDTO[] = [];
  filterTerm!: string;
  constructor(private pharmacyService: PharmacyService) {}

  ngOnInit(): void {
    this.getPagedList();
  }

  getPagedList(searchKey?:string): void {
    const criteria: PagedCriteriaObject = new PagedCriteriaObject();
    criteria.currentPage = 1;
    criteria.recordsCountOfPerPage = 10;
    criteria.searchKey=searchKey;
    this.pharmacyService.getPharmacyPagedList(criteria)
      .then((response) => {
        if (response.success && response.result?.success && response.result.items != null) {
          this.items = response.result.items;
        } else {
          this.items = [];
        }
      })
      .catch((error) => {
        console.error('An error occurred while fetching pharmacy data:', error);
      });
  }
  onKey(event: any) { // without type info
    this.filterTerm = event.target.value ;
    if (this.filterTerm.length>=3) {
      this.getPagedList(this.filterTerm);
    }else{
      this.ngOnInit();
    }
  }
  
}
