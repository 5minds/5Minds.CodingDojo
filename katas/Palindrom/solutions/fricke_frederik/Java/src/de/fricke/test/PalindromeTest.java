package de.fricke.test;

import de.fricke.Palindrome;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;

public class PalindromeTest {
    @Test
    public void SimplePalindromeTest()
    {
        Palindrome palindrome = new Palindrome();
        assertTrue(palindrome.IsPalindrome("abba"));
        assertTrue(palindrome.IsPalindrome("Lagerregal"));
        assertTrue(palindrome.IsPalindrome("Reliefpfeiler"));
        assertTrue(palindrome.IsPalindrome("Rentner"));
        assertTrue(palindrome.IsPalindrome("Dienstmannamtsneid"));
        assertFalse(palindrome.IsPalindrome("abcde"));
    }

    @Test
    public void ExtendedPalindromeTest()
    {
        Palindrome palindrome = new Palindrome();
        assertTrue(palindrome.IsPalindrome("Tarne nie deinen Rat!"));
        assertTrue(palindrome.IsPalindrome("Eine güldne, gute Tugend: Lüge nie!"));
        assertTrue(palindrome.IsPalindrome("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"));
        assertFalse(palindrome.IsPalindrome("Eine einfache Falch-Prüfung"));
    }
}
