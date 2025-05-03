import { Component, OnInit } from '@angular/core';
import { FileNote } from '../shared/file-note.model';
import { File } from '../shared/file.model';
import { NoteBase } from '../shared/note-base.model';
import { TextNote } from '../shared/text-note.model';
import { MatDialog } from '@angular/material/dialog';
import { AddFileNoteComponent } from './add-file-note/add-file-note.component';
import { AddTextNoteComponent } from './add-text-note/add-text-note.component';
import { Subject } from '../shared/subject.model';
import { User } from '../shared/user.model';
import { Type } from '../shared/type.model';
import { NotesService } from './notes.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  public date: Date = new Date();

  public todaysDate: Date = new Date();

  constructor(private _dialog: MatDialog, public _notesService: NotesService) { }

  ngOnInit(): void {
    this._notesService.chooseDate(new Date());
    this._notesService.updateMonthNotes(new Date());
  }

  public dayHasNote(day: Date){
    return this._notesService.monthNotes.find(n => {
      var d = new Date(n.deadLine);
      return d.getDate() == day?.getDate();
    }) ? true : false;
  }

  public nextMonth(){
    this.date.setMonth(this.date.getMonth() + 1);
    this._notesService.updateMonthNotes(this.date);
  }

  public previousMonth(){
    this.date.setMonth(this.date.getMonth() - 1);
    this._notesService.updateMonthNotes(this.date);
  }


  public getMonthArray(){
    var firstDay = new Date(this.date.getFullYear(), this.date.getMonth(), 1);
    var lastDay = new Date(this.date.getFullYear(), this.date.getMonth() + 1, 0);
    
    var array: any[] = [];
    var dayOfWeek = firstDay.getDay();
    for (let i = 0; i < dayOfWeek; i++) {
      array.push(null);
    }

    for (let i = 1; i <= lastDay.getDate(); i++) {
      array.push(firstDay);
      firstDay = new Date(firstDay.getFullYear(), firstDay.getMonth(), firstDay.getDate() + 1);
    }

    return array;
  }

  public openAddTextNoteDialog(){
    this._dialog.open(AddTextNoteComponent);
  }

  public openAddFileNoteDialog(){
    this._dialog.open(AddFileNoteComponent);
  }

  public readonly months: string[] = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];
}
