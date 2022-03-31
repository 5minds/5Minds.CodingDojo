"use strict";

let content = document.getElementById("content");
let firstNumber = new SpecialNumber( 3 , "Fizz" );
let secondNumber = new SpecialNumber( 5 , "Buzz" );
let outputString = "";

for ( let i = 1; i < 101; i++) {
    outputString = i.toString();
    if ( firstNumber.checkNumber( i ) && ! secondNumber.checkNumber( i ) ) {
        outputString = firstNumber.special_word;
    }
    else if ( ! firstNumber.checkNumber( i ) && secondNumber.checkNumber( i ) ) {
        outputString = secondNumber.special_word;
    }
    else if ( firstNumber.checkNumber( i ) && secondNumber.checkNumber( i ) ) {
        outputString = firstNumber.special_word + secondNumber.special_word;
    }
    content.innerHTML +=  outputString + "<br />";
}
