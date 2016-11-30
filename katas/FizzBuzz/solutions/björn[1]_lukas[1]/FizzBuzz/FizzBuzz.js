'use strict'

function modulo (number) {
  if (number%15 ===0) {
    return 'FizzBuzz';
  } else {
    if (number%3 === 0) {
      return 'Fizz';
    }
    if (number%5 ===0) {
      return 'Buzz';
    }
    return number;
  }
}

for (let i = 1; i < 101; i++) {
    console.log(modulo(i));
}
