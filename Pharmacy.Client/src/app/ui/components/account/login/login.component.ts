import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/app/services/common/alertservices/alertservice.service';
import { AccountService } from 'src/app/services/common/accountservices/accountservice.service';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
  })
export class LoginComponent implements OnInit {
  form=new FormGroup({
    tCKN:new FormControl(null,Validators.required),
    password:new FormControl(null,Validators.required),
  });


    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private accountService: AccountService,
        private alertService: AlertService
    ) { }
    submitForm(){
      if (this.form.invalid) {
        return;
      }
    }
    ngOnInit() {

    }



    onSubmit() {
        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }


          this.accountService.login(this.form.get('tCKN')?.value,this.form.get('password')?.value)
        .pipe(first())
        .subscribe((response)=>{
          this.router.navigate(['/dashboard']);
        });



    }
}
