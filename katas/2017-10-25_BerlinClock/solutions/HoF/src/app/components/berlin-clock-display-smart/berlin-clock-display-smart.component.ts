import { Component, OnInit } from '@angular/core';
import { BerlinClockTimerService } from 'src/app/services/berlin-clock-timer.service';

@Component({
  selector: 'app-berlin-clock-display-smart',
  templateUrl: './berlin-clock-display-smart.component.html',
  styleUrls: ['./berlin-clock-display-smart.component.css']
})
export class BerlinClockDisplaySmartComponent implements OnInit {

  constructor(public berlinClockTimerService: BerlinClockTimerService) { }

  ngOnInit() {
  }

}
