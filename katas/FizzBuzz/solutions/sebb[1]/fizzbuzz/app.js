 'use strict';

 const Fizzbuzzer = require('./fizzbuzzer');
 const fizzbuzzer = new Fizzbuzzer();

 const n = 100;
 console.log(`Run fizzbuzzer for ${n}`);
 const fizzBuzzerString = fizzbuzzer.getFizzBuzzerStringToN(n);
 console.log(`Result: ${fizzBuzzerString}`);