'use strict';

const debug = require('debug')('pta_solution:berlin_clock');

class BerlinClock {

  constructor(secondBlock, minuteBlock1, minuteBlock2, hourBlock1, hourBlock2) {
    this.secondBlock = secondBlock;
    this.minuteBlock1 = minuteBlock1;
    this.minuteBlock2 = minuteBlock2;
    this.hourBlock1 = hourBlock1;
    this.hourBlock2 = hourBlock2;
  }

  static fromEpoch(epoch) {
    const time = new Date(epoch);

    const secondBlock = time.getSeconds() % 2;
    const minuteBlock1 = Math.floor(time.getMinutes() / 5);
    const minuteBlock2 = time.getMinutes() - minuteBlock1 * 5;
    const hourBlock1 = Math.floor(time.getHours() / 5);
    const hourBlock2 = time.getHours() - hourBlock1 * 5;

    return new BerlinClock(secondBlock, minuteBlock1, minuteBlock2, hourBlock1, hourBlock2);
  }

}

module.exports = BerlinClock;
