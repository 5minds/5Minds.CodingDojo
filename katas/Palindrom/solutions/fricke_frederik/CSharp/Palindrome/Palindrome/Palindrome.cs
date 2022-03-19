namespace Palindrome;

public class Palindrome
{
    public bool IsPalindrome(string checkString)
    {
        checkString = checkString.ToLower();
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