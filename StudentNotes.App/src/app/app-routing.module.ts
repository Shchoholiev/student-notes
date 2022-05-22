import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './account/auth.guard';
import { LoginComponent } from './account/login/login.component';
import { ProfileComponent } from './account/profile/profile.component';
import { RegisterComponent } from './account/register/register.component';
import { CalendarComponent } from './calendar/calendar.component';
import { GroupComponent } from './groups/group/group.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: CalendarComponent, canActivate: [AuthGuard] },
  { path: 'account/profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'account/login', component: LoginComponent },
  { path: 'account/register', component: RegisterComponent },
  { path: 'group', component: GroupComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
