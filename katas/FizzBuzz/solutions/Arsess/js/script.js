"use strict";

let content = document.getElementById("content");
let firstNumber = new SpecialNumber( 3 , "Fizz" );
let secondNumber = new SpecialNumber( 5 , "Buzz" );
let outputString = "";

for ( let i = 1; i < 101; i++) {

    // Convert the number to string.
    outputString = i.toString();

    // Check the number ...
    if ( firstNumber.checkNumber( i ) && ! secondNumber.checkNumber( i ) ) {
        outputString = firstNumber.special_word;
    }
    else if ( ! firstNumber.checkNumber( i ) && secondNumber.checkNumber( i ) ) {
        outputString = secondNumber.special_word;
    }
    else if ( firstNumber.checkNumber( i ) && secondNumber.checkNumber( i ) ) {
        outputString = firstNumber.special_word + secondNumber.special_word;
    }

    // Send output to the client.
    content.innerHTML +=  outputString + "<br />";
}
