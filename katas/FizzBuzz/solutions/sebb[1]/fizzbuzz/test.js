'use strict';

const Fizzbuzzer = require('./fizzbuzzer');
const fizzbuzzer = new Fizzbuzzer();

testForFactor(15, 'FizzBuzz', 100);
testForFactor(5, 'Buzz', 15);
testForFactor(3, 'Fizz', 15);

function testForFactor(factor, shouldValue, ignoreFactor) {
  console.log(`Testing fizzbuzzer for multiplicatives of ${factor}: `);
  for (let i = factor; i < 100; i = i + factor) {
    if (i % ignoreFactor === 0) continue;
    let result = fizzbuzzer.getValueForNumber(i);
    console.log(`Current int: ${i}, result: ${result}`);
    if (result !== shouldValue) {
      console.log(`Test failed. Value should be ${shouldValue}`);
      return false;
    }
  }
  console.log('Test passed.');
  return true;
}  
