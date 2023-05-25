import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PharmaciesComponent } from './pharmacies.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    PharmaciesComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"pharmacies",component:PharmaciesComponent}
    ])
  ]
})
export class PharmaciesModule { }
