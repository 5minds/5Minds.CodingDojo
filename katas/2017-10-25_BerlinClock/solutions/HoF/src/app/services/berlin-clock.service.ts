import { Injectable } from '@angular/core';
import { BerlinClockData } from '../classes/berlin-clock-data';

@Injectable({
  providedIn: 'root'
})
export class BerlinClockService {

  constructor() { }

  GetBerlinClockData(currentTime: Date): BerlinClockData {
    return new BerlinClockData(currentTime);
  }
}
