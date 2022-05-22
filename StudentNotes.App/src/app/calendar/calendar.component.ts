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

  public dayNotes: NoteBase[] = [];

  public monthNotes: NoteBase[] = [];

  public date: Date = new Date();

  public todaysDate: Date = new Date();

  public chosenDate: Date = new Date();

  constructor(private _dialog: MatDialog, private _notesService: NotesService) { }

  ngOnInit(): void {
    // var author = new User();
    // author.name = "Петя";
    // var type = new Type();
    // type.name = "Какойто тип";
    // var textNote = new TextNote("Test", "Text text text");
    // var subject = new Subject();
    // subject.name = "ОПИ";
    // textNote.subject = subject;
    // textNote.author = author;
    // textNote.type = type;
    // this.dayNotes.push(textNote);
    // var files = [new File("File", "https://i.pinimg.com/474x/e0/a6/34/e0a634df2123584a23342f48efe0dbba.jpg")];
    // var fileNote = new FileNote(files);
    // fileNote.subject = subject;
    // fileNote.author = author;
    // fileNote.type = type;
    // this.dayNotes.push(fileNote);
    this.chooseDate(new Date());
    this.updateMonthNotes(new Date());
  }

  public dayHasNote(day: Date){
    return this.monthNotes.find(n => {
      var d = new Date(n.deadLine);
      return d.getDate() == day?.getDate();
    }) ? true : false;
  }

  public nextMonth(){
    this.date.setMonth(this.date.getMonth() + 1);
    this.updateMonthNotes(this.date);
  }

  public previousMonth(){
    this.date.setMonth(this.date.getMonth() - 1);
    this.updateMonthNotes(this.date);
  }

  public updateMonthNotes(date: Date){
    this._notesService.getMonthNotes(date).subscribe(
      response => this.monthNotes = response
    );
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
    this._notesService.getDayNotes(date).subscribe(
      response => this.dayNotes = response
    )
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
