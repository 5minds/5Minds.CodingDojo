package de.fricke;

import java.util.Locale;

public class Palindrome {
    public boolean IsPalindrome(String textToCheck)
    {
        textToCheck = textToCheck.toLowerCase();
        int length = textToCheck.length() - 1;
        for (int counter = 0; counter <= length; counter++)
        {
            if (!(textToCheck.charAt(counter) == textToCheck.charAt(length - counter))) return false;
        }
        return true;
    }
}
