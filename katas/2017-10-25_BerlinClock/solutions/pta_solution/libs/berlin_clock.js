'use strict';

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
    const hourBlock1 = Math.floor(time.getHours() / 5);
    const hourBlock2 = time.getHours() - hourBlock1 * 5;
    const minuteBlock1 = Math.floor(time.getMinutes() / 5);
    const minuteBlock2 = time.getMinutes() - minuteBlock1 * 5;

    return new BerlinClock(
      secondBlock
      , minuteBlock1
      , minuteBlock2
      , hourBlock1
      , hourBlock2
    );
  }

  // This function returns the raw datapoints to a client.
  // The client code can be kept stupid and doesnt need to know
  // about the crude structure of the berlin clock.
  // Instead folk can focus on 3bit booleans...
  static raw(epoch) {
    const berlinClock = BerlinClock.fromEpoch(epoch);

    const hourBlock1 = new Array(4)
      .fill(false)
      .fill(true, 0, berlinClock.hourBlock1);
    const hourBlock2 = new Array(4)
      .fill(false)
      .fill(true, 0, berlinClock.hourBlock2);
    const minuteBlock2 = new Array(4)
      .fill(false)
      .fill(true, 0, berlinClock.minuteBlock2);

    // apparently, every third minute indicator is different...
    const first = new Array(berlinClock.minuteBlock1).fill(true)
    .map((_, idx) => {
      if ((idx + 1) % 3 === 0) {
        return null;
      }

      return true;
    });

    const second = new Array(11 - berlinClock.minuteBlock1).fill(false);
    const minuteBlock1 = first.concat(second);

    const raw = [
      [!berlinClock.secondBlock],
      hourBlock1,
      hourBlock2,
      minuteBlock1,
      minuteBlock2,
    ];

    return raw;
  }

}

module.exports = BerlinClock;
