#!/usr/bin/env node

'use strict';

let platters = 0;
const towers = {1: [], 2: [], 3: []};
let moveCount = 0;

function run() {

  platters = parseInt(process.argv[2]);
  for (let i = 0; i < platters; i++) {
    towers[1].push(platters - i);
  }

  log();
  moveTower(1, 3, 0);
  console.log(moveCount);
}

function moveTower(source, target, startIndex)
{
  if (startIndex == platters)
    return;

  const spare = 6 - (source + target);
  moveTower(source, spare, startIndex + 1);
  move(source, target);
  moveTower(spare, target, startIndex + 1);
}

function move(from, to) {
  towers[to].push(towers[from].pop());
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
    layers[i] = `${towers[1][platters - (i + 1)] || 0} ${towers[2][platters - (i + 1)] || 0} ${towers[3][platters - (i + 1)] || 0}`;
  }

  console.log(`${layers.join('\n')}\n------\n`);
}

run();