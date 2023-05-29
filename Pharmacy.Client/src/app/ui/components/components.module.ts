import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from './home/home.module';
import { PharmaciesModule } from './pharmacies/pharmacies.module';




@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    HomeModule,
    PharmaciesModule
  ]
})
export class ComponentsModule { }
