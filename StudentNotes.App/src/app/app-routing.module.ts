import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { ProfileComponent } from './account/profile/profile.component';
import { RegisterComponent } from './account/register/register.component';
import { CalendarComponent } from './calendar/calendar.component';
import { GroupComponent } from './groups/group/group.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: CalendarComponent },
  { path: 'account/profile', component: ProfileComponent },
  { path: 'account/login', component: LoginComponent },
  { path: 'account/register', component: RegisterComponent },
  { path: 'group', component: GroupComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
