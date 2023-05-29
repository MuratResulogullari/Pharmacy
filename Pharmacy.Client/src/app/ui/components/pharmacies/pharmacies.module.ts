import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PharmaciesComponent } from './pharmacies.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PharmaciesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      {path:"",component:PharmaciesComponent}
    ])
  ]
})
export class PharmaciesModule { }
