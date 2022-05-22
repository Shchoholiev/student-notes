import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NoteBase } from '../shared/note-base.model';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  private readonly _baseURL = 'https://localhost:7243/api/notes';

  constructor(private _http: HttpClient) { }

  public getDayNotes(day: Date){
    return this._http.get<NoteBase[]>(`${this._baseURL}/day?year=${day.getFullYear()}&month=${day.getMonth() + 1}&day=${day.getDate()}`);
  }

  public getMonthNotes(day: Date){
    return this._http.get<NoteBase[]>(`${this._baseURL}/month?year=${day.getFullYear()}&month=${day.getMonth() + 1}`);
  }
}
