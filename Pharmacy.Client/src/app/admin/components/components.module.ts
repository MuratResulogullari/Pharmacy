import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PharmaciesModule } from './pharmacies/pharmacies.module';
import { UsersModule } from './users/users.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { LogsModule } from './logs/logs.module';




@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    DashboardModule,
    PharmaciesModule,
    UsersModule,
    LogsModule
  ]
})
export class ComponentsModule { }
