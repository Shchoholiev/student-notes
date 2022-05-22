import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Type } from '../shared/type.model';

@Injectable({
  providedIn: 'root'
})
export class TypesService {

  private readonly _baseURL = 'https://localhost:7243/api/types';

  constructor(private _http: HttpClient) { }

  public get(id: number){
    return this._http.get<Type>(`${this._baseURL}/${id}`);
  }

  public getPage(pageNumber: number, pageSize: number){
    return this._http.get<Type[]>(`${this._baseURL}`, { params: { 
                                                          pageSize: pageSize, 
                                                          pageNumber: pageNumber
                                                        }, observe: 'response' });
  }
}
