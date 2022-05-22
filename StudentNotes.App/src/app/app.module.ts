import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalendarComponent } from './calendar/calendar.component';
import { TextNoteComponent } from './calendar/text-note/text-note.component';
import { FileNoteComponent } from './calendar/file-note/file-note.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddTextNoteComponent } from './calendar/add-text-note/add-text-note.component';
import { AddFileNoteComponent } from './calendar/add-file-note/add-file-note.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { ProfileComponent } from './account/profile/profile.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthInterceptor } from './auth-interceptor';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    CalendarComponent,
    TextNoteComponent,
    FileNoteComponent,
    AddTextNoteComponent,
    AddFileNoteComponent,
    ProfileComponent,
    NavigationBarComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    MatDialogModule,
    FormsModule,
    MatButtonModule,
    BrowserAnimationsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["shchoholiev-chat.azurewebsites.net"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
