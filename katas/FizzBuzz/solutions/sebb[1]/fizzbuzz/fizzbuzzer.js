'use strict';

class fizzbuzzer {
  getFizzBuzzerStringToN(n) {
    let fizzBuzzerString = '';
    for (let i = 1; i < n; i++) {
      const value = this.getValueForNumberExtended(i);
      fizzBuzzerString = `${fizzBuzzerString}${value}`;
      if (i < n - 1) fizzBuzzerString = `${fizzBuzzerString}, `;
    }
    return fizzBuzzerString;
  }

  getValueForNumber(n) {
    if (n % (3 * 5) === 0) return 'FizzBuzz';
    if (n % (3) === 0) return 'Fizz';
    if (n % (5) === 0) return 'Buzz';
    return n.toString();
  }

  getValueForNumberExtended(n) {
    const nStr = n.toString();
    if (nStr.includes('5') && nStr.includes('3')) return 'FizzBuzz';
    if (nStr.includes('5')) return 'Buzz';
    if (nStr.includes('3')) return 'Fizz';
    return this.getValueForNumber(n);
  }
}

module.exports = fizzbuzzer;