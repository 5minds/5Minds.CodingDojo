"use strict";

class SpecialNumber {
    constructor(special_number, special_word) {
        this.special_number = special_number;
        this.special_word = special_word;
    }
    checkNumber(newNumber) {
        if (newNumber % this.special_number == 0 || newNumber.toString().indexOf( this.special_number.toString() ) != -1 ) {
            return true;
        }
        else {
            return false;
        }
    }
}
