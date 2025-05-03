import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { GroupsService } from '../groups/groups.service';
import { Group } from '../shared/group.model';
import { User } from '../shared/user.model';
import { AuthService } from './auth.service';
import { Login } from './login/login.model';
import { Register } from './register/register.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private readonly baseURL = 'https://localhost:7243/api/account';

  constructor(private _http: HttpClient, private _authService: AuthService, private _router: Router,
              private _groupsService: GroupsService) { }

  public register(form: Register){
    this._http.post<any>(this.baseURL + '/register', form).subscribe(
      response => {
        this._authService.login(response);
        this.getProfile().subscribe(
          response => {
            var user = response as User;
            this._authService.avatar = user.avatar;
            if (form.isLeader) {
              var group = new Group();
              group.name = form.additionalText;
              group.users = [user];
              this._groupsService.create(group).subscribe();
            }
            else
            {
              this._groupsService.getByInviteCode(form.additionalText).subscribe(
                response => {
                  var group = response as Group;
                  user.group = group;
                  this.update(user).subscribe();
                }
              );
            }
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

  public update(user: User){
    return this._http.put(`${this.baseURL}`, user);
  }
}
