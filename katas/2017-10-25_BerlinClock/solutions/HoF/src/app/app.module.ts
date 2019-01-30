import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BerlinClockDisplayComponent } from './components/berlin-clock-display/berlin-clock-display.component';
import { BerlinClockDisplaySmartComponent } from './components/berlin-clock-display-smart/berlin-clock-display-smart.component';

@NgModule({
  declarations: [
    AppComponent,
    BerlinClockDisplayComponent,
    BerlinClockDisplaySmartComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
