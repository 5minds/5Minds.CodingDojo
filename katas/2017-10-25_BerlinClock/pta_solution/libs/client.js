'use strict';

// Its surprisingly hard to make an UI that doesn't look like a toddler's work..
const chalk = require('chalk');

const BerlinClock = require('./berlin_clock');

const REPEAT = 4;
const SEPARATOR = '-';
const SIGN = '#';

// client sends data to the "service" so its possible to bypass timezone shenanigans
const raw = BerlinClock.raw(Date.now());

function drawSingle(row, size, times) {

  const line = row.map((isActive) => {
    const colorWrapper = isActive === true
      ? chalk.yellow
      : chalk.gray;

    return colorWrapper(`${' '.repeat(16)}${SIGN.repeat(size)}`)
  })
  .join();

  console.log(line);

  if (times > 1) {
    drawSingle(row, size, times - 1);
  }
}

function drawBigElement(row, size, times) {
  const line = row.map((isActive) => {
    const colorWrapper = isActive === true
      ? chalk.yellow
      : isActive === false
        ? chalk.gray
        : chalk.red;

    return colorWrapper(SIGN.repeat(size));
  })
  .join(' ');

  console.log(line);
  if (times > 1) {
    drawBigElement(row, size, times - 1);
  }
}

function separator(separator, times) {
  console.log(SEPARATOR.repeat(times));
}

function drawAll() {
  drawSingle(raw[0], 10, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[1], 10, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[2], 10, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[3], 3, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[4], 10, REPEAT);
}

drawAll();
