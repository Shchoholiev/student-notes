import { Component, OnInit } from '@angular/core';
import { FileNote } from 'src/app/shared/file-note.model';
import { Subject } from 'src/app/shared/subject.model';
import { Type } from 'src/app/shared/type.model';
import { SubjectsService } from 'src/app/subjects/subjects.service';
import { TypesService } from 'src/app/types/types.service';
import { NotesService } from '../notes.service';
import { HelpersService } from "src/app/shared/helpers.service";
import { File } from 'src/app/shared/file.model';

@Component({
  selector: 'app-add-file-note',
  templateUrl: './add-file-note.component.html',
  styleUrls: ['./add-file-note.component.css']
})
export class AddFileNoteComponent implements OnInit {

  public note: FileNote = new FileNote([]);

  public types: Type[] = [];

  public subjects: Subject[] = [];

  public createFile: File = new File("","");

  constructor(private _typesService: TypesService, private _subjectsService: SubjectsService,
              private _notesService: NotesService, private _helpersService: HelpersService) { }

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
    this._notesService.createFileNote(this.note).subscribe(
      r => {
        this._notesService.chooseDate(this._notesService.chosenDate);
        this._notesService.updateMonthNotes(this._notesService.chosenDate);
      }
    );
  }

  public fileToLink(event: Event){
    var input = event.target as HTMLInputElement;
    if (input.files) {
      this._helpersService.fileToLink('avatars', input?.files[0]).subscribe(
        response => this.createFile.link = (<any>response).link
      );
    }
  }

  public addFile(){
    this.note.files.push(this.createFile);
    this.createFile = new File("","");
  }
}
