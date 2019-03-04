'use strict';

// Its surprisingly hard to make an UI that doesn't look like a toddler's work..
const chalk = require('chalk');

const BerlinClock = require('./berlin_clock');

// Potential Client options...
const REPEAT = 4;
const SEPARATOR = '-';
const SIGN = '#';
const INTERVAL = 100;

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

function drawBigElement(row, activeColor, size, times) {
  const line = row.map((isActive) => {
    const colorWrapper = isActive === true
      ? activeColor
      : isActive === false
        ? chalk.gray
        : chalk.red;

    return colorWrapper(SIGN.repeat(size));
  })
  .join(' ');

  console.log(line);
  if (times > 1) {
    drawBigElement(row, activeColor, size, times - 1);
  }
}

function separator(separator, times) {
  console.log(SEPARATOR.repeat(times));
}

function drawAll(raw) {
  console.clear();
  drawSingle(raw[0], 10, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[1], chalk.red, 10, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[2], chalk.red, 10, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[3], chalk.yellow, 3, REPEAT);
  separator(SEPARATOR, 43);
  drawBigElement(raw[4], chalk.yellow, 10, REPEAT);
}

function whatsTheTime() {
  // client sends data to the "service" so its possible
  // to bypass timezone shenanigans
  const raw = BerlinClock.raw(Date.now());
  drawAll(raw);
}

setInterval(() => {
  whatsTheTime();
}, INTERVAL);
