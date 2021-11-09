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
        public static List<object[]> IsPalindromTestData = new List<object[]>();

        [Theory]
        [MemberData(nameof(IsPalindromTestData))]
        public void IsPalindrome_ReturnsCorrectResult(string text, bool expected)
        {
            var checker = new PalindromChecker();
            var result = checker.IsPalindrom(text);
            Assert.Equal(expected, result);
        }
    }
}
