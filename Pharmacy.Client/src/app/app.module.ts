import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { UiModule } from './ui/ui.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsModule } from "./admin/layout/components/components.module";
import { HttpClientModule } from '@angular/common/http';
import { AlertComponent } from './helpers/alert/alert.component';

import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        AppComponent,
        AlertComponent
    ],
    providers: [
      {provide:"baseUrl",useValue:"https://localhost:7060/api",multi:true}
    ],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        AdminModule,
        UiModule,
        BrowserAnimationsModule,
        ComponentsModule,
        HttpClientModule,
        ReactiveFormsModule
    ]
})
export class AppModule { }
