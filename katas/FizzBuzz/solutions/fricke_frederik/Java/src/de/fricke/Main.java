package de.fricke;

import java.io.IOException;

public class Main {

    public static void main(String[] args) throws IOException {
        System.out.println("FizzBuzz!!!");

        FizzBuzz fizzBuzz = new FizzBuzz();
        for (int counter = 1; counter <= 100; counter++)
        {
            if (counter == 100) System.out.println(fizzBuzz.isFizzBuzz(counter));
            else {
                System.out.print(fizzBuzz.isFizzBuzz(counter) + ", ");
                if (counter % 5 == 0) System.out.println();
            }
        }
        //noinspection ResultOfMethodCallIgnored
        System.in.read();
    }
}
