import { HttpClient } from '@angular/common/http';
import { not } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { FileNote } from '../shared/file-note.model';
import { NoteBase } from '../shared/note-base.model';
import { TextNote } from '../shared/text-note.model';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  private readonly _baseURL = 'https://localhost:7243/api/notes';

  public monthNotes: NoteBase[] = [];

  public chosenDate: Date = new Date();

  public dayNotes: NoteBase[] = [];

  constructor(private _http: HttpClient) { }

  public getDayNotes(day: Date){
    return this._http.get<NoteBase[]>(`${this._baseURL}/day?year=${day.getFullYear()}&month=${day.getMonth() + 1}&day=${day.getDate()}`);
  }

  public getMonthNotes(day: Date){
    return this._http.get<NoteBase[]>(`${this._baseURL}/month?year=${day.getFullYear()}&month=${day.getMonth() + 1}`);
  }

  public createTextNote(note: TextNote){
    var date = new Date(this.chosenDate);
    note.deadLine = new Date(date.setDate(this.chosenDate.getDate() + 1));
    return this._http.post(`${this._baseURL}/text-note`, note);
  }

  public createFileNote(note: FileNote){
    var date = new Date(this.chosenDate);
    note.deadLine = new Date(date.setDate(this.chosenDate.getDate() + 1));
    return this._http.post(`${this._baseURL}/file-note`, note);
  }

  public chooseDate(date: Date){
    this.chosenDate = date;
    this.getDayNotes(date).subscribe(
      response => this.dayNotes = response
    )
  }

  public updateMonthNotes(date: Date){
    this.getMonthNotes(date).subscribe(
      response => this.monthNotes = response
    );
  }
}
