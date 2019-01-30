import { Component, OnInit, Input } from '@angular/core';
import { BerlinClockData } from 'src/app/classes/berlin-clock-data';

@Component({
  selector: 'app-berlin-clock-display',
  templateUrl: './berlin-clock-display.component.html',
  styleUrls: ['./berlin-clock-display.component.css']
})
export class BerlinClockDisplayComponent implements OnInit {

  @Input()
  berlinClockData: BerlinClockData;

  constructor() { }

  ngOnInit() {
  }

}
