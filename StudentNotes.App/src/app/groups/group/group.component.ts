import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { AuthService } from 'src/app/account/auth.service';
import { Group } from 'src/app/shared/group.model';
import { User } from 'src/app/shared/user.model';
import { GroupsService } from '../groups.service';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {

  public group: Group = new Group();

  constructor(private _groupsService: GroupsService, private _accountService: AccountService) { }

  ngOnInit(): void {
    this._accountService.getProfile().subscribe(
      response => {
        var user = response as User;
        this._groupsService.get(user.group.id).subscribe(
          response => this.group = response as Group
        )
      }
    )
  }

  public isHeadman(user: User){
    return user?.roles?.some(r => r.name == "Headman");
  }
}
