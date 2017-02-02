#!/usr/bin/env node

'use strict';

let platters = 0;
const towers = {1: [], 2: [], 3: []};
let moveCount = 0;

function run() {

  platters = parseInt(process.argv[2]);
  for (let i = 0; i < platters; i++) {
    towers[1][i] = platters - i;
    towers[2][i] = 0;
    towers[3][i] = 0;
  }

  log();
  moveTower1To3(0);
  console.log(moveCount);
}

function moveTower1To2(startIndex) {
  if (startIndex == platters)
    return;

  moveTower1To3(startIndex + 1);
  move(1, 2);
  moveTower3To2(startIndex + 1);
}

function moveTower1To3(startIndex) {
  if (startIndex == platters)
    return;

  moveTower1To2(startIndex + 1);
  move(1, 3);
  moveTower2To3(startIndex + 1);
}

function moveTower2To1(startIndex) {
  if (startIndex == platters)
    return;

  moveTower2To3(startIndex + 1);
  move(2, 1);
  moveTower3To1(startIndex + 1);
}

function moveTower2To3(startIndex) {
  if (startIndex == platters)
    return;

  moveTower2To1(startIndex + 1);
  move(2, 3);
  moveTower1To3(startIndex + 1);
}

function moveTower3To1(startIndex) {
  if (startIndex == platters)
    return;

  moveTower3To2(startIndex + 1);
  move(3, 1);
  moveTower2To1(startIndex + 1);
}

function moveTower3To2(startIndex) {
  if (startIndex == platters)
    return;

  moveTower3To1(startIndex + 1);
  move(3, 2);
  moveTower1To2(startIndex + 1);
}

function move(from, to) {
  moveCount++;
  let fromIndex = 0;
  for (let i = platters - 1; i >= 0; i--) {
    if (towers[from][i] != 0) {
      fromIndex = i;
      break;
    }
  }

  let toIndex = 0;
  for (let i = platters - 1; i >= 0; i--) {
    if (towers[to][i] != 0) {
      toIndex = i + 1;
      break;
    }
  }
  
  towers[to][toIndex] = towers[from][fromIndex];
  towers[from][fromIndex] = 0;

  check();
  log();
}

function check() {
  for (let i = 1; i < 4; i++) {
    for (let j = platters - 1; j > 0; j--) {
      if (towers[i][j] > towers[i][j - 1]) {
        log();
        throw new Error('Invalid state');
      }
    }
  }
}

function log() { 
  const layers = new Array(platters);
  for (let i = 0; i < platters; i++) {
    layers[i] = `${towers[1][platters - (i + 1)]} ${towers[2][platters - (i + 1)]} ${towers[3][platters - (i + 1)]}`;
  }

  console.log(`${layers.join('\n')}\n------\n`);
}

run();