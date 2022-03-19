package de.fricke;

public class FizzBuzz {

    public String isFizzBuzz(int numToCheck)
    {
        String outString = "";

        if (numToCheck % 3 == 0) outString += "Fizz";
        if (numToCheck % 5 == 0) outString += "Buzz";

        outString = CheckString(numToCheck, outString);

        if (outString.equals("")) outString = Integer.toString(numToCheck);

        return outString;
    }

    private String CheckString(int numToCheck, String prevFizzBuzzString)
    {
        String outString = prevFizzBuzzString;
        String numString = Integer.toString(numToCheck);

        if (numString.contains("3") && !(outString.contains("Fizz"))) outString = "Fizz" + outString;
        if (numString.contains("5") && !(outString.contains("Buzz"))) outString += "Buzz";

        return outString;
    }
}
