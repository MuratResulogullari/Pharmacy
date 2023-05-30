import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from './home/home.module';
import { PharmaciesModule } from './pharmacies/pharmacies.module';
import { AccountModule } from './account/account.module';




@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    HomeModule,
    PharmaciesModule,
    AccountModule
  ]
})
export class ComponentsModule { }
