import { Component, OnInit } from '@angular/core';
import { Login } from './login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public user: Login = new Login();

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(){
    
  }
}
