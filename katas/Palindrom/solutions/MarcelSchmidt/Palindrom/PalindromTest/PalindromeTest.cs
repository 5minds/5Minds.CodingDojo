using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrom;
using System.Collections.Generic;

namespace PalindromTest
{
    [TestClass]
    public class PalindromeTest
    {
        [TestMethod]
        public void IsPalindrome_CaseInsensitiveCheck_WordCaseInsensitive_ReturnsTrue()
        {
            CaseInsensitiveCheckSucceed(PalindromeExamples.PalindromesCaseInsensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseSensitiveCheck_WordCaseInsensitive_ReturnsFalse()
        {
            CaseSensitiveCheckFail(PalindromeExamples.PalindromesCaseInsensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseInsensitiveCheck_WordCaseSensitive_ReturnsTrue()
        {
            CaseInsensitiveCheckSucceed(PalindromeExamples.PalindromesCaseSensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseSensitiveCheck_WordCaseSensitive_ReturnsTrue()
        {
            CaseSensitiveCheckSucceed(PalindromeExamples.PalindromesCaseSensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseSensitiveCheck_WordNoPalindrome_ReturnsFalse()
        {
            CaseSensitiveCheckFail(PalindromeExamples.NoPalindromes);
        }

        [TestMethod]
        public void IsPalindrome_CaseInsensitiveCheck_WordNoPalindrome_ReturnsFalse()
        {
            CaseInsensitiveCheckFail(PalindromeExamples.NoPalindromes);
        }

        [TestMethod]
        public void IsPalindrome_CaseInsensitiveCheck_SentenceCaseInsensitive_ReturnsTrue()
        {
            CaseInsensitiveCheckSucceed(PalindromeExamples.PalindromeSentencesCaseInsensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseSensitiveCheck_SentenceCaseInsensitive_ReturnsFalse()
        {
            CaseSensitiveCheckFail(PalindromeExamples.PalindromeSentencesCaseInsensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseInsensitiveCheck_SentenceCaseSensitive_ReturnsTrue()
        {
            CaseInsensitiveCheckSucceed(PalindromeExamples.PalindromeSentencesCaseSensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseSensitiveCheck_SentenceCaseSensitive_ReturnsTrue()
        {
            CaseSensitiveCheckSucceed(PalindromeExamples.PalindromeSentencesCaseSensitive);
        }

        [TestMethod]
        public void IsPalindrome_CaseSensitiveCheck_SentenceNoPalindrome_ReturnsFalse()
        {
            CaseSensitiveCheckFail(PalindromeExamples.NoPalindromeSentences);
        }

        [TestMethod]
        public void IsPalindrome_CaseInsensitiveCheck_SentenceNoPalindrome_ReturnsFalse()
        {
            CaseInsensitiveCheckFail(PalindromeExamples.NoPalindromeSentences);
        }
        
        private static void CaseInsensitiveCheckFail(IEnumerable<string> palindromes)
        {
            foreach (var palindrome in palindromes)
            {
                if (Palindrome.IsPalindrome(palindrome, true))
                {
                    Assert.Fail("{0} is for some reason classified as a palindrome", palindrome);
                }
            }
        }

        private static void CaseInsensitiveCheckSucceed(IEnumerable<string> palindromes)
        {
            foreach (var palindrome in palindromes)
            {
                if (!Palindrome.IsPalindrome(palindrome, true))
                {
                    Assert.Fail("{0} is no palindrome", palindrome);
                }
            }
        }

        private static void CaseSensitiveCheckFail(IEnumerable<string> palindromes)
        {
            foreach (var palindrome in palindromes)
            {
                if (Palindrome.IsPalindrome(palindrome))
                {
                    Assert.Fail("{0} is for some reason classified as a palindrome", palindrome);
                }
            }
        }

        private static void CaseSensitiveCheckSucceed(IEnumerable<string> palindromes)
        {
            foreach (var palindrome in palindromes)
            {
                if (!Palindrome.IsPalindrome(palindrome))
                {
                    Assert.Fail("{0} is no palindrome", palindrome);
                }
            }
        }
    }
}
