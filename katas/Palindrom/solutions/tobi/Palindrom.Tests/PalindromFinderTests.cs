using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Palindrom.Tests
{
    public class PalindromFinderTests
    {
        public static List<object[]> IsPalindromTestData = new List<object[]>()
        {
            new object[] { "Abba", true },
            new object[] { "Lagerregal", true },
            new object[] { "Reliefpfeiler", true },
            new object[] { "Rentner", true },
            new object[] { "Dienstmannamtsneid", true },
            new object[] { "Tarne nie deinen Rat!", true },
            new object[] { "Eine güldne, gute Tugend: Lüge nie!", true },
            new object[] { "Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!", true },
            new object[] { "Palindrom", false },
            new object[] { "Abbx", false },
            new object[] { "a", true },
            new object[] { "", true },
            new object[] { null, true },
        };

        [Theory]
        [MemberData(nameof(IsPalindromTestData))]
        public void IsPalindrome_ReturnsCorrectResult(string text, bool expected)
        {
            var checker = new PalindromChecker();
            var result = checker.IsPalindrom(text);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(IsPalindromTestData))]
        public void IsPalindromeRecursive_ReturnsCorrectResult(string text, bool expected)
        {
            var checker = new PalindromChecker();
            var result = checker.IsPalindromeRecursive(text);
            Assert.Equal(expected, result);
        }
    }
}
