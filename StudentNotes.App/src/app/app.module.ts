import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalendarComponent } from './calendar/calendar.component';
import { TextNoteComponent } from './calendar/text-note/text-note.component';
import { FileNoteComponent } from './calendar/file-note/file-note.component';

@NgModule({
  declarations: [
    AppComponent,
    CalendarComponent,
    TextNoteComponent,
    FileNoteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
