import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppService } from './app.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    HttpModule,
    BrowserModule
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
