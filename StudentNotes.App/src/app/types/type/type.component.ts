import { Component, Input, OnInit } from '@angular/core';
import { Type } from 'src/app/shared/type.model';

@Component({
  selector: 'app-type',
  templateUrl: './type.component.html',
  styleUrls: ['./type.component.css']
})
export class TypeComponent implements OnInit {

  @Input()type: Type = new Type();

  constructor() { }

  ngOnInit(): void {
  }

}
