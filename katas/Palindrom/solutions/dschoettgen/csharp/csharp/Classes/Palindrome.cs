using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.Classes
{
    /// <summary>
    /// Class Palindrome: Check if a given string a Palindrome
    /// </summary>
    public class Palindrome
    {
        private string givenValue;
        private string invertedValue;

        private readonly char[] punctuationAndSpace  = new char[]{
            ' ',
            ',',
            '.',
            ':',
            '!',
            '?',
            ';',
            '-',
            '(',
            ')',
            '/'
        };

        /// <summary>
        /// Check if a given string a palindrome
        /// </summary>
        /// <param name="value">a string to compare</param>
        /// <returns>bool</returns>
        public bool IsPalindrome(string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                givenValue = string.Join("", value.Split(punctuationAndSpace)).ToLower();
                char[] charArrayGivenValue = givenValue.ToCharArray();
                Array.Reverse(charArrayGivenValue);
                invertedValue = new string(charArrayGivenValue);

                if (givenValue == invertedValue)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
