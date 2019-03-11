import com.fizzbuzz.vivek.Constants;
import com.fizzbuzz.vivek.FizzBuzzAlgo;
import com.fizzbuzz.vivek.FizzBuzzInterface;
import org.junit.Assert;
import org.junit.Test;

import java.util.Arrays;
import java.util.List;

public class FizzBuzzTest {

    @Test
    public void checkIfFizzBuzzListHasCorrectFizzBuzzes(){
        FizzBuzzInterface fizzBuzzAlgo = new FizzBuzzAlgo(100, 3, 5);
        List<String> fizzBuzzList = fizzBuzzAlgo.returnNumbersInFizzBuzz();

        //Check at position 3 it is Fizz.
        Assert.assertEquals(Constants.FIZZ, fizzBuzzList.get(2));

        //Check at position 5 it is Buzz
        Assert.assertEquals(Constants.BUZZ, fizzBuzzList.get(4));

        //Check at position 15 it is FizzBuzz
        Assert.assertEquals(Constants.FIZZBUZZ, fizzBuzzList.get(14));

        //Check at position 13 it is Fizz
        Assert.assertEquals(Constants.FIZZ, fizzBuzzList.get(12));

        //Check at position 35 it is FizzBuzz
        Assert.assertEquals(Constants.FIZZBUZZ, fizzBuzzList.get(34));

        //Check at position 53 it is FizzBuzz
        Assert.assertEquals(Constants.FIZZBUZZ, fizzBuzzList.get(52));

        //Check at position 4 it is just a normal number and no Fizz/Buzz
        Assert.assertEquals("4", fizzBuzzList.get(3));
    }

    @Test
    public void checkIfFizzBuzzWorksForOtherFizzBuzzRangeCombination() {
        FizzBuzzInterface fizzBuzzAlgo = new FizzBuzzAlgo(50, 2, 3);
        List<String> fizzBuzzList = fizzBuzzAlgo.returnNumbersInFizzBuzz();

        //Check at position 2 it is Fizz.
        Assert.assertEquals(Constants.FIZZ, fizzBuzzList.get(1));

        //Check at position 3 it is Buzz
        Assert.assertEquals(Constants.BUZZ, fizzBuzzList.get(2));

        //Check at position 6 it is FizzBuzz
        Assert.assertEquals(Constants.FIZZBUZZ, fizzBuzzList.get(5));

        //Check at position 23 it is FizzBuzz.
        Assert.assertEquals(Constants.FIZZBUZZ, fizzBuzzList.get(22));

        //Check at position 33 it is Buzz.
        Assert.assertEquals(Constants.BUZZ, fizzBuzzList.get(32));

        //Check at position 32 it is FizzBuzz
        Assert.assertEquals(Constants.FIZZBUZZ, fizzBuzzList.get(31));

        //Check at position 7 it is just a normal number and no Fizz/Buzz
        Assert.assertEquals("7", fizzBuzzList.get(6));
    }

    @Test
    public void compareStaticListWithAlgoGeneratedFizzBuzzList() {
        FizzBuzzInterface fizzBuzzAlgo = new FizzBuzzAlgo(10, 2, 3);
        List<String> fizzBuzzList = fizzBuzzAlgo.returnNumbersInFizzBuzz();
        List<String> expectedList = Arrays.asList("1", "Fizz", "Buzz", "Fizz", "5", "FizzBuzz", "7", "Fizz", "Buzz", "Fizz");
        Assert.assertEquals(expectedList,fizzBuzzList);
    }
}
