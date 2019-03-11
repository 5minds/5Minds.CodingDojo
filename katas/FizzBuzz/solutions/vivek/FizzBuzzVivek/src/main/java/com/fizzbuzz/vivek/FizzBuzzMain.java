package com.fizzbuzz.vivek;

import java.util.List;

public class FizzBuzzMain {

    public static void main(String[] args) {
        //Max Range of natural numbers
        int maxRange = 100;

        /*
         * Since this kata needed to be tested for 3 and 5 for fizz and buzz respectively, I extended the algo
         * functionality to test other possible combinations and hence made fizzNumber and buzzNumber that are
         * passed as arguments to FizzBuzzAlgo along with max range.
         */
        //Number to be called 'Fizz'
        int fizzNumber = 3;

        //Number to be called 'Buzz'
        int buzzNumber = 5;

        /*
         * New instance of algo class.. Since there are 3 parameters that needs to be configured for fizz buzz test,
         * they are passed as constructor arguments. If the config parameters become more than 4, then would consider
         * a builder or a config object.
         */
        FizzBuzzInterface fizzBuzzAlgo = new FizzBuzzAlgo(maxRange, fizzNumber, buzzNumber);

        //Check fizz or buzz or fizzbuzz in FizzBuzzAlgo class
        List<String> numbersTilMaxRange = fizzBuzzAlgo.returnNumbersInFizzBuzz();

        //Print out numbers with fizz or buzz or fizzbuzz
        System.out.println(numbersTilMaxRange);
    }
}
