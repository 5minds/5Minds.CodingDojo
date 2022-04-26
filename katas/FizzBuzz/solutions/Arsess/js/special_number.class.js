"use strict";

/**
 * Class SpecialNumber.
 *
 * It make a special number with a method to check if any given number is devidable or include it.
 *
 */
class SpecialNumber {

    /*
     * constructor of the class
     *
     * @param special_number is the main number of the class
     * @param special_word is the word to replace if checkNumber send the true
     *
     */
    constructor(special_number, special_word) {
        this.special_number = special_number;
        this.special_word = special_word;
    }

    /*
     * Method checkNumber checks a given number if it dividable or include the main number of the class
     *
     * @param newNumber is the given number to check
     *
     * @return boolian send true if it dividable or include the main number of the class is.
     */
    checkNumber(newNumber) {
        if (newNumber % this.special_number == 0 || newNumber.toString().indexOf( this.special_number.toString() ) != -1 ) {
            return true;
        }
        else {
            return false;
        }
    }
}
