'use strict';

class Fizzbuzz {
  /**
   * @method fizzbuzz returns the value with following rules:
   * For multiples of 3, return "Fizz".
   * For multiples of 5, return "Buzz".
   * For multiples of 3 and 5 return "FizzBuzz".
   * @param {number} value 
   * @return {string | number} result
   * 
   */
  fizzbuzz(value) {
    if (isNaN(value) ||
      value === null ||
      typeof value === 'object' ||
      typeof value === "boolean"
    ) throw new Error('Please enter valid number');
    if (value === 0) return value;
    
    if (value % 15 == 0) {
      return 'FizzBuzz';
    } else if (value % 3 == 0) {
      return 'Fizz';
    } else if (value % 5 == 0) {
      return 'Buzz';
    }

    return value;
  }
  
  /**
   * @method fizzbuzzWithVariation returns the value with following rules:
   * Fizz "should also be returned if the number contains a 3 as a digit, e.g. 13th
   * "Buzz" should also be returned if the number contains a 5 as a digit, e.g. 52nd
   * "FizzBuzz" should also be returned if the number contains a 3 and a 5, e.g. 35 or 53.
   * @param {number} value 
   * @return {string | number} result
   * 
   */
  fizzbuzzWithVariation(value) {
    if (isNaN(value) ||
      value === null ||
      typeof value === 'object' ||
      typeof value === "boolean"
    ) throw new Error('Please enter valid number');
    const stringValue = value.toString();
    if (stringValue.includes('5') && stringValue.includes('3')) {
      return 'FizzBuzz';
    }
    if (stringValue.includes('5')) {
      return 'Buzz';
    }
    if (stringValue.includes('3')) {
      return 'Fizz';
    }
    return value;
  }
}

module.exports = Fizzbuzz;