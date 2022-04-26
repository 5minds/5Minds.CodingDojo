package de.fricke.Test;

import de.fricke.FizzBuzz;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class FizzBuzzTest {

    @Test
    public void FizzTest()
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
        assertEquals("Fizz", fizzBuzz.isFizzBuzz(6));
        assertEquals("Fizz", fizzBuzz.isFizzBuzz(9));
        assertEquals("Fizz", fizzBuzz.isFizzBuzz(12));
        assertEquals("Fizz", fizzBuzz.isFizzBuzz(31));
        assertEquals("Fizz", fizzBuzz.isFizzBuzz(73));
    }

    @Test
    public void BuzzTest()
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
        assertEquals("Buzz", fizzBuzz.isFizzBuzz(10));
        assertEquals("Buzz", fizzBuzz.isFizzBuzz(55));
        assertEquals("Buzz", fizzBuzz.isFizzBuzz(52));
        assertEquals("Buzz", fizzBuzz.isFizzBuzz(58));
    }

    @Test
    public void CompleteFizzBuzzTest()
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
        assertEquals("FizzBuzz", fizzBuzz.isFizzBuzz(15));
        assertEquals("FizzBuzz", fizzBuzz.isFizzBuzz(53));
        assertEquals("FizzBuzz", fizzBuzz.isFizzBuzz(35));
    }
}
