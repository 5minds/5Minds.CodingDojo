namespace Palindrome;

public class Palindrome
{
    public bool IsPalindrome(string checkString)
    {
        checkString = checkString.ToLower();
        checkString = checkString.Replace(" ", "")
            .Replace("!", "")
            .Replace(".", "")
            .Replace("?", "")
            .Replace(",", "")
            .Replace(":", "")
            .Replace("\n", "")
            .Replace("\t", "")
            .Replace("\r", "")
            .Replace("\n", "");
        
        int length = checkString.Length - 1;
        for (int counter = 0; counter <= length ; counter++)
        {
            if (!checkString[counter].Equals(checkString[length - counter]))
            {
                return false;
            }
        }
        return true;
    }
}