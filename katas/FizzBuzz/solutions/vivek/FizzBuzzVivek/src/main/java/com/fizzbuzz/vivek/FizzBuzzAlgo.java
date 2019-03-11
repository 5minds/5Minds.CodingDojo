package com.fizzbuzz.vivek;

import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class FizzBuzzAlgo implements FizzBuzzInterface {

    private int maxRange;
    private int fizzNumber;
    private int buzzNumber;
    private String fizzNumberStr;
    private String buzzNumberStr;

    /**
     * Constructor that takes max range, fizz number and buzz number as parameters
     *
     * @param maxRange   max range til the fiz buzz logic should occur
     * @param fizzNumber fizz number
     * @param buzzNumber buzz number
     */
    public FizzBuzzAlgo(final int maxRange, final Integer fizzNumber, final Integer buzzNumber) {
        this.maxRange = maxRange;
        this.fizzNumberStr = fizzNumber.toString();
        this.buzzNumberStr = buzzNumber.toString();
        this.fizzNumber = fizzNumber;
        this.buzzNumber = buzzNumber;
    }

    /**
     * Check fizz buzz in the range
     * @return fizz buzz numbers in the range
     */
    @Override
    public List<String> returnNumbersInFizzBuzz() {
        return IntStream.rangeClosed(1, maxRange).mapToObj(number ->
                checkFizzBuzz(number)).collect(Collectors.toList());
    }

    /**
     * Check fizz buzz for a given number
     * @param number number whose fizz or buzz should be checked
     * @return is fizz or buzz
     */
    String checkFizzBuzz(final int number) {
        boolean isBuzz = number % buzzNumber == 0 || Integer.toString(number).contains(buzzNumberStr);
        boolean isFizz = number % fizzNumber == 0 || Integer.toString(number).contains(fizzNumberStr);

        if (isFizz && isBuzz) {
            return Constants.FIZZBUZZ;
        } else if (isFizz) {
            return Constants.FIZZ;
        } else if (isBuzz) {
            return Constants.BUZZ;
        } else {
            return String.valueOf(number);
        }
    }
}
