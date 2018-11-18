import { Injectable } from '@angular/core';
import { BerlinClockService } from './berlin-clock.service';
import { interval, BehaviorSubject, Observable } from 'rxjs';
import { BerlinClockData } from '../classes/berlin-clock-data';

@Injectable({
  providedIn: 'root'
})
export class BerlinClockTimerService {
  private berlinClockDataSubject: BehaviorSubject<BerlinClockData> = new BehaviorSubject(null);

  public readonly berlinClockData: Observable<BerlinClockData> = this.berlinClockDataSubject.asObservable();

  constructor(private berlinClockService: BerlinClockService) {
    interval(1000).subscribe(() => this.berlinClockDataSubject.next(berlinClockService.GetBerlinClockData(new Date())));
   }
}
