'use strict';

const Fizzbuzz = require('./fizzbuzz');
const fizzbuzz = new Fizzbuzz();

console.log('-------------fizzbuzz--------------------------');
for (let i = 1; i <= 100; i++) {
  console.log(fizzbuzz.fizzbuzz(i));
}

console.log('-----------fizzbuzzWithVariation---------------');
for (let i = 1; i <= 100; i++) {
  console.log(fizzbuzz.fizzbuzzWithVariation(i));
}
