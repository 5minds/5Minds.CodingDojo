'use strict';
const assert = require('assert');
const Fizzbuzz = require('./fizzbuzz');
const fizzbuzz = new Fizzbuzz();

function assertEquals(expected, actual, value) {
  assert.equal(expected, actual,
    'Expected ' + actual + ' to equal ' + expected + ' for value ' + value);
}

// fizzbuzz tests
[15, 30, 45, 60].forEach(function (value) {
  assertEquals('FizzBuzz', fizzbuzz.fizzbuzz(value));
});

[3, 6, 9, 12, 18, 21, 24, 27, 33].forEach(function (value) {
  assertEquals('Fizz', fizzbuzz.fizzbuzz(value));
});

[5, 10, 20, 25, 35, 40].forEach(function (value) {
  assertEquals('Buzz', fizzbuzz.fizzbuzz(value));
});

[1, 2, 4, 7, 8, 11].forEach(function (value) {
  assertEquals(value, fizzbuzz.fizzbuzz(value));
});

assert.throws(() => {
  fizzbuzz.fizzbuzz(true);
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzz('abc');
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzz({});
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzz([]);
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzz(undefined);
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzz(null);
}, Error);

assert.doesNotThrow(function () {
  fizzbuzz.fizzbuzz('33');
}, 'Valid number as string throws error');


// fizzbuzzWithVariation tests
[3, 13, 23, 30, 31, 37, 43, 63, 73, 83, 93].forEach(function (value) {
  assertEquals('Fizz', fizzbuzz.fizzbuzzWithVariation(value), value);
});

[5, 15, 25, 45, 55, 51, 57, 65, 75, 85, 95].forEach(function (value) {
  assertEquals('Buzz', fizzbuzz.fizzbuzzWithVariation(value), value);
});

[35, 53].forEach(function (value) {
  assertEquals('FizzBuzz', fizzbuzz.fizzbuzzWithVariation(value), value);
});

[1, 2, 4, 7, 8, 11, 22, 47, 64, 72, 81, 94].forEach(function (value) {
  assertEquals(value, fizzbuzz.fizzbuzzWithVariation(value));
});

assert.throws(() => {
  fizzbuzz.fizzbuzzWithVariation(true);
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzzWithVariation('abc');
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzzWithVariation({});
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzzWithVariation([]);
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzzWithVariation(undefined);
}, Error);

assert.throws(() => {
  fizzbuzz.fizzbuzzWithVariation(null);
}, Error);

assert.doesNotThrow(function () {
  fizzbuzz.fizzbuzzWithVariation('33');
}, 'Valid number as string throws error');

console.log('Test passed')