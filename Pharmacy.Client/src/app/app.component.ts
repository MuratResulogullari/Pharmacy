import { Component } from '@angular/core';
declare var $:any
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Pharmacy.Client';
}
$.get("https://localhost:7060/api/User/GetUserById/2", function( ) {
  alert( "Data Loaded: "  );
})