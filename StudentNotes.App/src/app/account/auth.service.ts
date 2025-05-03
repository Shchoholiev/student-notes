import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../shared/user.model';
import { Tokens } from './tokens.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _jwtHelper: JwtHelperService, private _router: Router) { }

  get name(){
    var token = localStorage.getItem("jwt");
    if (token != null) {
      var decodedToken = this._jwtHelper.decodeToken(token);
      return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    }
  }

  get email(){
    var token = localStorage.getItem("jwt");
    if (token != null) {
      var decodedToken = this._jwtHelper.decodeToken(token);
      return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
    }
  }

  get avatar(){
    var link = localStorage.getItem("avatar");
    if (link) {
      return link;
    }
    return "";
  }

  get isAuthenticated(){
    var token = localStorage.getItem("jwt");
    return token && !this._jwtHelper.isTokenExpired(token);
  }

  set avatar(link: string){
    localStorage.setItem('avatar', link);
  }

  login(token: Tokens){
    localStorage.setItem('jwt', token.accessToken);
    localStorage.setItem('refreshToken', token.refreshToken);
  }

  logout(){
    localStorage.removeItem('jwt');
    localStorage.removeItem('refreshToken');
    this._router.navigate(['account/login']);
  }
}
