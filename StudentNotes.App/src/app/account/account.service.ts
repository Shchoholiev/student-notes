import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../shared/user.model';
import { AuthService } from './auth.service';
import { Login } from './login/login.model';
import { Register } from './register/register.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private readonly baseURL = 'https://localhost:7243/api/account';

  constructor(private _http: HttpClient, private _authService: AuthService, private _router: Router) { }

  public register(form: Register){
    this._http.post<any>(this.baseURL + '/register', form).subscribe(
      response => {
        this._authService.login(response);
        this.getProfile().subscribe(
          response => {
            var user = response as User;
            this._authService.avatar = user.avatar;
            this._router.navigate(['']);
          }
        )
      }
    );
  }

  public login(form: Login){
    this._http.post<any>(this.baseURL + '/login', form).subscribe(
      response => {
        this._authService.login(response);
        this.getProfile().subscribe(
          response => {
            var user = response as User;
            this._authService.avatar = user.avatar;
            this._router.navigate(['']);
          }
        )
      }
    );
  }

  public getProfile(){
    return this._http.get(`${this.baseURL}`);
  }
}
