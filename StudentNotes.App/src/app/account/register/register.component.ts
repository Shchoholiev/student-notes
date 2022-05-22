import { Component, OnInit } from '@angular/core';
import { Register } from './register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public user = new Register();

  public text = "Invite code";

  constructor() { }

  ngOnInit(): void {
  }

  public onSubmit(){

  }

  public check(){
    this.text = (!this.user.isLeader) ? "Group name" : "Invite code";
  }
}
