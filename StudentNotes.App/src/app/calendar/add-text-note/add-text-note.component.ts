import { Component, OnInit } from '@angular/core';
import { Subject } from 'src/app/shared/subject.model';
import { TextNote } from 'src/app/shared/text-note.model';
import { Type } from 'src/app/shared/type.model';
import { SubjectsService } from 'src/app/subjects/subjects.service';
import { TypesService } from 'src/app/types/types.service';
import { NotesService } from '../notes.service';

@Component({
  selector: 'app-add-text-note',
  templateUrl: './add-text-note.component.html',
  styleUrls: ['./add-text-note.component.css']
})
export class AddTextNoteComponent implements OnInit {

  public note: TextNote = new TextNote("", "");

  public types: Type[] = [];

  public subjects: Subject[] = [];

  constructor(private _typesService: TypesService, private _subjectsService: SubjectsService,
              private _notesService: NotesService) { }

  ngOnInit(): void {
    this._typesService.getPage(1, 12).subscribe(
      response => this.types = response.body || []
    );
    this._subjectsService.getPage(1, 12).subscribe(
      response => this.subjects = response.body || []
    );
  }

  public setType(type: Type){
    this.note.type = type;
  }

  public setSubject(subject: Subject){
    this.note.subject = subject;
  }

  public onSubmit(){
    this._notesService.createTextNote(this.note).subscribe(
      r => {
        this._notesService.chooseDate(this._notesService.chosenDate);
        this._notesService.updateMonthNotes(this._notesService.chosenDate);
      }
    );
  }
}
