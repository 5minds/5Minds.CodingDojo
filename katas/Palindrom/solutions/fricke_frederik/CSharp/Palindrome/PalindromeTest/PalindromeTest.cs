using NUnit.Framework;

namespace PalindromeTest;
using Palindrome;

public class Tests
{
    private Palindrome _palindrome;
    
    [SetUp]
    public void Setup()
    {
        _palindrome = new Palindrome();
    }

    [Test]
    public void SimplePalindromeTest()
    {
        Assert.True(_palindrome.IsPalindrome("Abba"));
        Assert.True(_palindrome.IsPalindrome("Lagerregal"));
        Assert.True(_palindrome.IsPalindrome("Reliefpfeiler"));
        Assert.True(_palindrome.IsPalindrome("Rentner"));
        Assert.True(_palindrome.IsPalindrome("Dienstmannamtsneid"));
        Assert.False(_palindrome.IsPalindrome("Test"));
    }

    [Test]
    public void SentencePalindromeTest()
    {
        Assert.True(_palindrome.IsPalindrome("Tarne nie deinen Rat!"));
        Assert.True(_palindrome.IsPalindrome("Eine güldne, gute Tugend: Lüge nie!"));
        Assert.True(_palindrome.IsPalindrome("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"));
        Assert.False(_palindrome.IsPalindrome("Dies ist ein einfacher Test für eine Falsch-Prüfung"));
    }
}