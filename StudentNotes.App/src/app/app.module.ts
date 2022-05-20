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

@NgModule({
  declarations: [
    AppComponent,
    CalendarComponent,
    TextNoteComponent,
    FileNoteComponent,
    AddTextNoteComponent,
    AddFileNoteComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatDialogModule,
    FormsModule,
    MatButtonModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
