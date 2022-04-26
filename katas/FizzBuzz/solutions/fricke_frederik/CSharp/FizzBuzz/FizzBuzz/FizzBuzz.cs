namespace FizzBuzz;

public class FizzBuzz
{
    /// <summary>
    /// This is the primary function which checks if the given number is
    /// Fizz, Buzz or FizzBuzz
    /// </summary>
    /// <param name="numToCheck">Number to check for FizzBuzz</param>
    /// <returns>Returns a string which has Fizz, Buzz or FizzBuzz</returns>
    public string IsFizzBuzz(int numToCheck)
    {
        string outString = "";


        if (numToCheck % 3 == 0) outString += "Fizz";
        if (numToCheck % 5 == 0) outString += "Buzz";

        outString = CheckString(numToCheck, outString);

        if (outString == "") outString = numToCheck.ToString();
        
        return outString;
    }

    /// <summary>
    /// A helper function used to search if the given number has
    /// the number 3 or 5 in it.
    /// </summary>
    /// <param name="numToCheck">The given number which shall be checked</param>
    /// <param name="outString">A string which will returned with Fizz, Buzz or FizzBuzz</param>
    /// <param name="prevFizzBuzzString">the previous FizzBuzz-String</param>
    private string CheckString(int numToCheck, string prevFizzBuzzString)
    {
        string intString = numToCheck.ToString();
        string outString = prevFizzBuzzString;

        if (intString.Contains('3') && !(outString.Contains("Fizz"))) outString = "Fizz" + outString;
        if (intString.Contains('5') && !(outString.Contains("Buzz"))) outString += "Buzz";

        return outString;
    }
}