import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { ProfileComponent } from './account/profile/profile.component';
import { CalendarComponent } from './calendar/calendar.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: CalendarComponent },
  { path: 'account/profile', component: ProfileComponent },
  { path: 'account/login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
