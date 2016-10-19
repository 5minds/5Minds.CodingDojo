'use strict';

function nextBigger(val) {

  const numbers = val.toString(10)
    .split('')
    .map(Number);

  const newNumber = val.toString(10)
    .split('')
    .map(Number);

  function getXBiggestNumber(index) {
    const sortedNumbers = numbers.sort()
      .reverse();

    return sortedNumbers[index];
  }

  function swap(indexA, indexB) {
    const numberA = numbers[indexA];
    const numberB = numbers[indexB];

    newNumber[indexA] = numberB;
    newNumber[indexB] = numberA;
  }

  function createNumber(numberArray) {

    let numberResult = '';

    for (let i = 0; i < numberArray.length; i++) {
      numberResult += numberArray[i].toString();
    }

    return parseInt(numberResult, 0);
  }

  for (let i = newNumber.length; i > 0; i--) {
    if (i > 0 && newNumber[i] > newNumber[i - 1]) {
      swap(i - 1, i);
      return createNumber(newNumber);
    }
  }

  if (createNumber(newNumber) === createNumber(numbers)) {
    return -1;
  }
}


/**
* nextBigger(12)==21
* nextBigger(513)==531
* nextBigger(2017)==2071
* nextBigger(459853)==483559 :(
 */
const cases = [12, 513, 2017, 459853, 9, 111, 531];

cases.forEach((testNumber) => {
  const result = nextBigger(testNumber);
  console.log(`Testing ${testNumber} => ${result}`);
});
