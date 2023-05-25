import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PharmaciesModule } from './pharmacies/pharmacies.module';
import { UsersModule } from './users/users.module';
import { LogsModule } from './logs/logs.module';
import { DashboardModule } from './dashboard/dashboard.module';




@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DashboardModule,
    PharmaciesModule,
    UsersModule,
    LogsModule
  ]
})
export class ComponentsModule { }
