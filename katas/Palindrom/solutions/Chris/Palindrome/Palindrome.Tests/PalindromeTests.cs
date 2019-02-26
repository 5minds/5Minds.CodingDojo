
using FluentAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Palindrome.Tests
{
    [TestClass]
    public class PalindromeTests
    {
        private Palindrome _palindrome;

        [TestInitialize]
        public void Initialize()
        {
            _palindrome = new Palindrome();
        }

        [TestMethod]
        public void PalindromeWordsShouldReturnTrue()
        {
            _palindrome.IsStringPalindrome("Abba").ShouldBeTrue();
            _palindrome.IsStringPalindrome("Lagerregal").ShouldBeTrue();
            _palindrome.IsStringPalindrome("Reliefpfeiler").ShouldBeTrue();
            _palindrome.IsStringPalindrome("Rentner").ShouldBeTrue();
            _palindrome.IsStringPalindrome("Dienstmannamtsneid").ShouldBeTrue();
        }

        [TestMethod]
        public void NonPalindromeWordsShouldReturnFalse()
        {
            _palindrome.IsStringPalindrome("Hallo").ShouldBeFalse();
            _palindrome.IsStringPalindrome("Liebe").ShouldBeFalse();
            _palindrome.IsStringPalindrome("5Minds").ShouldBeFalse();
            _palindrome.IsStringPalindrome("Viel").ShouldBeFalse();
            _palindrome.IsStringPalindrome("Spaß").ShouldBeFalse();
        }

        [TestMethod]
        public void PalindromeSentencesShouldReturnTrue()
        {
            _palindrome.IsStringPalindrome("Tarne nie deinen Rat!").ShouldBeTrue();
            _palindrome.IsStringPalindrome("Eine güldne, gute Tugend: Lüge nie! ").ShouldBeTrue();
            _palindrome.IsStringPalindrome("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!").ShouldBeTrue();
        }

        [TestMethod]
        public void NonPalindromeSentencesShouldReturnFalse()
        {
            _palindrome.IsStringPalindrome("Lorem Ipsum is simply dummy text of the printing and typesetting industry.").ShouldBeFalse();
            _palindrome.IsStringPalindrome("Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.").ShouldBeFalse();
        }
    }
}
