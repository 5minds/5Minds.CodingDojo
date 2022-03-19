namespace FizzBuzz;

public class FizzBuzz
{
    /// <summary>
    /// This is the primary function which checks if the given number is
    /// Fizz, Buzz or FizzBuzz
    /// </summary>
    /// <param name="intToCheck">Number to check for FizzBuzz</param>
    /// <returns>Returns a string which has Fizz, Buzz or FizzBuzz</returns>
    public string IsFizzBuzz(int intToCheck)
    {
        string outString = "";
        
        if (intToCheck % 3 == 0)
        {
            outString = intToCheck % 5 == 0 ? "FizzBuzz" : "Fizz";
        } else if (intToCheck % 5 == 0)
        {
            outString = "Buzz";
        }
        
        if (outString != "") return outString;
        CheckString(intToCheck, out outString);

        if (outString == "") outString = intToCheck.ToString();
        
        return outString;
    }
    
    /// <summary>
    /// A helper function used to search if the given number has
    /// the number 3 or 5 in it.
    /// </summary>
    /// <param name="intToCheck">The given number which shall be checked</param>
    /// <param name="outString">A string which will returned with Fizz, Buzz or FizzBuzz</param>
    private void CheckString(int intToCheck, out string outString)
    {
        outString = "";
        
        string intString = intToCheck.ToString();
        if (intString.Contains('3'))
        {
            outString = intString.Contains('5') ? "FizzBuzz" : "Fizz";
        }
        else if (intString.Contains('5'))
        {
            outString = "Buzz";
        }
    }
}