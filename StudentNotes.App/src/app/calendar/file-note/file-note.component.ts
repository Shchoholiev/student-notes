import { Component, Input, OnInit } from '@angular/core';
import { FileNote } from 'src/app/shared/file-note.model';

@Component({
  selector: 'app-file-note',
  templateUrl: './file-note.component.html',
  styleUrls: ['../calendar.component.css', './file-note.component.css']
})
export class FileNoteComponent implements OnInit {
  
  @Input() note: FileNote;

  constructor() { }

  ngOnInit(): void {
  }

}
