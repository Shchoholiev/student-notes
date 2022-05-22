import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Group } from '../shared/group.model';

@Injectable({
  providedIn: 'root'
})
export class GroupsService {

  private readonly _baseURL = 'https://localhost:7243/api/groups';

  constructor(private _http: HttpClient) { }

  public get(id: number){
    return this._http.get<Group>(`${this._baseURL}/${id}`);
  }

  public getByInviteCode(inviteCode: string){
    return this._http.get<Group>(`${this._baseURL}/by-invite-code/${inviteCode}`);
  }

  public create(group: Group){
    return this._http.post(this._baseURL, group);
  }

  public update(group: Group){
    return this._http.put(`${this._baseURL}/${group.id}`, group);
  }

  public refreshInviteCode(group: Group){
    return this._http.put(`${this._baseURL}/refresh-invite-code/${group.id}`, group);
  }
}
