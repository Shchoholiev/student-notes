import { Component, OnInit } from '@angular/core';
import { FileNote } from '../shared/file-note.model';
import { File } from '../shared/file.model';
import { NoteBase } from '../shared/note-base.model';
import { TextNote } from '../shared/text-note.model';
import { MatDialog } from '@angular/material/dialog';
import { AddFileNoteComponent } from './add-file-note/add-file-note.component';
import { AddTextNoteComponent } from './add-text-note/add-text-note.component';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  public dayNotes: NoteBase[] = [];

  public monthNotes: NoteBase[] = [];

  public date: Date = new Date();

  public todaysDate: Date = new Date();

  public chosenDate: Date = new Date();

  constructor(private _dialog: MatDialog) { }

  ngOnInit(): void {
    var textNote = new TextNote("Test", "Text text text");
    this.dayNotes.push(textNote);
    var files = [new File("File", "https://i.pinimg.com/474x/e0/a6/34/e0a634df2123584a23342f48efe0dbba.jpg")];
    var fileNote = new FileNote(files);
    this.dayNotes.push(fileNote);
  }

  public nextMonth(){
    this.date.setMonth(this.date.getMonth() + 1);
    //more logic coming
  }

  public previousMonth(){
    this.date.setMonth(this.date.getMonth() - 1);
    //more logic coming
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

  public chooseDate(date: Date){
    this.chosenDate = date;
    //more logic coming
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
