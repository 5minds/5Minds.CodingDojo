import { Injectable } from '@angular/core';
import { BerlinClockData } from '../classes/berlin-clock-data';

@Injectable({
  providedIn: 'root'
})
export class BerlinClockService {

  constructor() { }

  GetBerlinClockData(currentTime: Date): BerlinClockData {
    const hours = currentTime.getHours();
    const hoursModFive = hours % 5;
    const minutes = currentTime.getMinutes();
    const minutesModFive = minutes % 5;
    const seconds = currentTime.getSeconds();

    const berlinClockData = new BerlinClockData();
    berlinClockData.isFiveHourLightOneOn = hours > 4;
    berlinClockData.isFiveHourLightTwoOn = hours > 9;
    berlinClockData.isFiveHourLightThreeOn = hours > 14;
    berlinClockData.isFiveHourLightFourOn = hours > 19;
    berlinClockData.isHourLightOneOn = hoursModFive > 0;
    berlinClockData.isHourLightTwoOn = hoursModFive > 1;
    berlinClockData.isHourLightThreeOn = hoursModFive > 2;
    berlinClockData.isHourLightFourOn = hoursModFive > 3;
    berlinClockData.isFiveMinuteLightOneOn = minutes > 4;
    berlinClockData.isFiveMinuteLightTwoOn = minutes > 9;
    berlinClockData.isFiveMinuteLightThreeOn = minutes > 14;
    berlinClockData.isFiveMinuteLightFourOn = minutes > 19;
    berlinClockData.isFiveMinuteLightFiveOn = minutes > 24;
    berlinClockData.isFiveMinuteLightSixOn = minutes > 29;
    berlinClockData.isFiveMinuteLightSevenOn = minutes > 34;
    berlinClockData.isFiveMinuteLightHeightOn = minutes > 39;
    berlinClockData.isFiveMinuteLightNineOn = minutes > 44;
    berlinClockData.isFiveMinuteLightTenOn = minutes > 49;
    berlinClockData.isFiveMinuteLightElevenOn = minutes > 54;
    berlinClockData.isMinuteLightOneOn = minutesModFive > 0;
    berlinClockData.isMinuteLightTwoOn = minutesModFive > 1;
    berlinClockData.isMinuteLightThreeOn = minutesModFive > 2;
    berlinClockData.isMinuteLightFourOn = minutesModFive > 3;
    berlinClockData.isSecondLightOn = seconds % 2 < 1;

    return berlinClockData;
  }
}
