'use strict';

//find the next bigger number from the same digits
// algorithm: 
// 1. find the first digit from the right, which is less than the previous (pos1)
// 2. find the next biggest digit d1 right to the found digit
// 3. move the found digit d1 to the position pos1
// 4. sort the rest right sub-array ascending
function nextBigger (number) {
    // convert into an array of digits
    var digitsArray = String(number).split("").map((num) => {
        return Number(num)
    })
    
    if (digitsArray.length == 1)
        return -1;

    // go the array from right to left and find the first digit (its position) that is less than the previous element
    var positionTochange = -1;
    for (var i = digitsArray.length - 2; i >= 0; i--) {
        if (digitsArray[i] < digitsArray[i + 1]) {
            // position found!
            positionTochange = i;
            break;
        }
    }
    if (positionTochange < 0)
        return -1;
    var digitToChange = digitsArray[positionTochange];
    // now, set to the found position the next bigger digit from the rest array part to the right from the found position

    // copy the left part of the array to the result array
    var result = new Array();
    for (var i = 0; i < positionTochange; i++)
        result.push(digitsArray.shift());
    var restBiggestDigits = digitsArray.filter(el => el > digitToChange).sort(function (a, b) {
        return a - b;
    });
    if (restBiggestDigits.length == 0)
        return -1;

    // the first element ist the next biggest digit to the found
    var digitToBePlacedFirst = restBiggestDigits[0];
    result.push(digitToBePlacedFirst);

    // remove the element from the initial array
    var indexToRemove = digitsArray.indexOf(digitToBePlacedFirst);
    if (indexToRemove >= 0)
        digitsArray.splice(indexToRemove, 1);

    // concat the result and the sorted initial array
    result = result.concat(digitsArray.sort(function (a, b) { return a - b;}))

    // output
    var resultNumber = parseInt(result.join(''), 10);
    if (resultNumber == number)
        return -1;

    return resultNumber;

}

var valuesArr = [2017, 12, 513, 459853, 59884848459853, 111, 9, 531];
valuesArr.forEach(el => console.log("nextBigger(%d) = %d", el, nextBigger(el)));

module.exports = nextBigger;