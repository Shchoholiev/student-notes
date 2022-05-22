import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  private readonly baseURL = 'https://localhost:7243/api/notes';

  constructor(private _http: HttpClient) { }
}
