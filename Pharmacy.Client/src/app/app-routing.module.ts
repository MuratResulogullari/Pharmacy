import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
  {
    path:"admin",component:LayoutComponent,children:[

    {path:"",component:DashboardComponent},
    {path:"",loadChildren:()=>import("./admin/components/pharmacies/pharmacies.module").then(module=>module.PharmaciesModule)},
    {path:"",loadChildren:()=>import("./admin/components/users/users.module").then(module=>module.UsersModule)},
    {path:"",loadChildren:()=>import("./admin/components/logs/logs.module").then(module=>module.LogsModule)},
   
  ]
  },
  {path:"",component:HomeComponent},
  {path:"pharmacies",loadChildren:()=>import("./ui/components/pharmacies/pharmacies.module").then(module=>module.PharmaciesModule)},
  {path:"account",loadChildren:()=>import("./ui/components/account/account.module").then(module=>module.AccountModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
