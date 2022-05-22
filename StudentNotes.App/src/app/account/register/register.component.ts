import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';
import { Register } from './register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public user = new Register();

  public text = "Invite code";

  constructor(private _accountService: AccountService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this._accountService.register(this.user);
  }

  public check(){
    this.text = (!this.user.isLeader) ? "Group name" : "Invite code";
  }
}
