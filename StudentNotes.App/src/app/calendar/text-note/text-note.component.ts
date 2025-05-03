import { Component, Input, OnInit } from '@angular/core';
import { TextNote } from 'src/app/shared/text-note.model';

@Component({
  selector: 'app-text-note',
  templateUrl: './text-note.component.html',
  styleUrls: ['../calendar.component.css', './text-note.component.css']
})
export class TextNoteComponent implements OnInit {

  @Input() note: TextNote;

  constructor() { }

  ngOnInit(): void {
  }

}
