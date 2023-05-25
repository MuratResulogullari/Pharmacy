import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users.component';
import { RouterModule } from '@angular/router';
import { RolesComponent } from '../roles/roles.component';



@NgModule({
  declarations: [
    UsersComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"users",component:UsersComponent},
      {path:"roles",component:RolesComponent}
    ])
  ]
})
export class UsersModule { }
