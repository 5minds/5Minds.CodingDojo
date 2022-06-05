using System;
using System.Linq;

namespace Palindrom
{
    public static class Palindrome
    {
        public static bool IsPalindrome(string input, bool ignoreCaseSensitivity = false)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input.Any(char.IsPunctuation) || input.Any(char.IsWhiteSpace))
            {
                input = new string(input.Where(x => !(char.IsPunctuation(x) || char.IsWhiteSpace(x))).ToArray());
            }

            var firstHalfLength = (int)Math.Floor(input.Length / 2d);
            var secondHalfStartIndex = (int)Math.Ceiling(input.Length / 2d);

            var firstHalf = input[0..firstHalfLength];
            var secondHalf = ReverseString(input[secondHalfStartIndex..]);

            return ignoreCaseSensitivity
                ? firstHalf.ToLower() == secondHalf.ToLower()
                : firstHalf == secondHalf;
        }

        private static string ReverseString(string s)
        {
            var array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
