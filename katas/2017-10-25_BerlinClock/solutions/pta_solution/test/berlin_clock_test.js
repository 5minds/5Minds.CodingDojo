'use strict';

const should = require('should');

const BerlinClock = require('./../libs/berlin_clock');

describe('berlin_clock', () => {
  it('should return a berlin clock like structure', () => {
    const structure = BerlinClock.fromEpoch(1551633804000); // Sunday, March 3, 2019 6:23:24 PM GMT+01:00

    should(structure).have.only.keys('secondBlock', 'minuteBlock1', 'minuteBlock2', 'hourBlock1', 'hourBlock2');
  });

  it('should return a berlin clock like structure with correct values', () => {
    const structure = BerlinClock.fromEpoch(1551633804000); // Sunday, March 3, 2019 6:23:24 PM GMT+01:00

    should(structure).not.be.undefined();
    should(structure).not.be.null();
    should(structure.secondBlock).be.equal(0);
    should(structure.minuteBlock1).be.equal(4);
    should(structure.minuteBlock2).be.equal(3);
    should(structure.hourBlock1).be.equal(3);
    should(structure.hourBlock2).be.equal(3);
  });
});
