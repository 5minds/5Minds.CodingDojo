using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom
{
    public interface IPalindromChecker
    {
        bool IsPalindrom(string text);
        bool IsPalindromeRecursive(string text);
    }

    public class PalindromChecker : IPalindromChecker
    {
        public bool IsPalindrom(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return true;
            }

            var textEx = cleanText(text);
            var textExReversed = new string(textEx.Reverse().ToArray());
            return string.Equals(textEx, textExReversed);
        }

        public bool IsPalindromeRecursive(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return true;
            }

            var cleanedText = cleanText(text);
            return checkForPalindrome(cleanedText, 0, cleanedText.Length - 1);
        }

        private string cleanText(string text)
        {
            return new string(text.ToLowerInvariant().Where(c => char.IsLetter(c)).ToArray());
        }

        private bool checkForPalindrome(string text, int start, int end)
        {
            if(start == end)
            {
                return true;
            }

            if(text[start] != text[end])
            {
                return false;
            }

            if(start < end + 1)
            {
                return checkForPalindrome(text, start + 1, end - 1);
            }

            return true;
        }
    }
}
