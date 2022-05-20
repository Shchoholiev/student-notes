import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/shared/group.model';
import { User } from 'src/app/shared/user.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public user: User = new User();

  constructor() { }

  ngOnInit(): void {
    this.user.name = "Petro";
    this.user.avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMx1itTXTXLB8p4ALTTL8mUPa9TFN_m9h5VQ&usqp=CAU";
    var group = new Group();
    group.name = "PZPI-21-4"
    this.user.group = group;
  }

}
