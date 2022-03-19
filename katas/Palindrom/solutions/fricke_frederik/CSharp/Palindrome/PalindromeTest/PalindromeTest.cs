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
    public void PalinTest()
    {
        Assert.True(_palindrome.IsPalindrome("Abba"));
        Assert.True(_palindrome.IsPalindrome("Lagerregal"));
        Assert.True(_palindrome.IsPalindrome("Reliefpfeiler"));
        Assert.True(_palindrome.IsPalindrome("Rentner"));
        Assert.True(_palindrome.IsPalindrome("Dienstmannamtsneid"));
        Assert.False(_palindrome.IsPalindrome("Test"));
    }
}