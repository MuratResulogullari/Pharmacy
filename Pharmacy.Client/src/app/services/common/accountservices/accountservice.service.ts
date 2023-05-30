import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { UserDTO } from 'src/app/contracts/users/user-dto';
import { HttpClientService } from '../http-client.service';
import { RequestResult } from 'src/app/contracts/base/request-result';


@Injectable({ providedIn: 'root' })
export class AccountService {
    private userSubject: BehaviorSubject<UserDTO | null>;
    public user: Observable<UserDTO | null>;
    private _isLoggedIn$ = new BehaviorSubject<boolean>(false);
    isLoggedIn$ = this._isLoggedIn$.asObservable();
    constructor(
        private router: Router,
        private http: HttpClient,
        private httpClientService:HttpClientService,
    ) {
        this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('user')!));
        this.user = this.userSubject.asObservable();
    }

    public get userValue() {
        return this.userSubject.value;
    }

    login(username: any, password?: any) {

     return this.httpClientService.post({
        controller:"user",
        action:"authenticate"
      },{ username, password }).pipe(
        tap((response: any) => {
          this._isLoggedIn$.next(true);
          localStorage.setItem('profanis_auth', response.token);
        })
      );
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['/account/login']);
    }

    register(user: UserDTO) {
        return  this.httpClientService.post({
          controller:"user",
          action:"authenticate"
        }, user);
    }

    getAll() {
        return  this.httpClientService.get<RequestResult<Array<UserDTO>>>({
          controller:"user",
          action:"getAll"
        }).subscribe(x=>{
          if(x.success && x.result !=null)
            return x.result;
          else
           return Array<UserDTO>
        });
    }

    getById(id: number) {
        return  this.httpClientService.get<RequestResult<UserDTO>>({
            controller:"user",
            action:"getUserById"
          },id).subscribe(x=>{
            if(x.success && x.result !=null)
              return x.result;
            else
             return Array<UserDTO>
          });
    }

    update(id: number, user: UserDTO) {
        user.id=id;
        return  this.httpClientService.post({
            controller:"user",
            action:"updateUser"
          }, user).pipe(map(x => {
            // update stored user if the logged in user updated their own record
            if (id == this.userValue?.id) {
                // update local storage
                const user = { ...this.userValue, ...this.user };
                localStorage.setItem('user', JSON.stringify(user));

                // publish updated user to subscribers
                this.userSubject.next(user);
            }
            return x;
        }));;
    }

    delete(id: number) {
        return  this.httpClientService.delete({
            controller:"user",
            action:"deleteUser"
          }, id).pipe(map(x => {
                // auto logout if the logged in user deleted their own record
                if (id == this.userValue?.id) {
                    this.logout();
                }
                return x;
            }));
    }
}
