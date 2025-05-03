import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from '../shared/subject.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectsService {

  private readonly _baseURL = 'https://localhost:7243/api/subjects';

  constructor(private _http: HttpClient) { }

  public get(id: number){
    return this._http.get<Subject>(`${this._baseURL}/${id}`);
  }

  public getPage(pageNumber: number, pageSize: number){
    return this._http.get<Subject[]>(`${this._baseURL}`, { params: { 
                                                          pageSize: pageSize, 
                                                          pageNumber: pageNumber
                                                        }, observe: 'response' });
  }
}
