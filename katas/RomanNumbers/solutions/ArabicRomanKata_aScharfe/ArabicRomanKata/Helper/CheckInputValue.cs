using System;
using System.Text.RegularExpressions;
using ArabicRomanKata.Enum;

namespace ArabicRomanKata.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class CheckInputValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static bool CheckValueIsValid(this string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                Console.WriteLine("No value was specified for the conversion.");
                return false;
            }

            if (int.TryParse(inputValue, out var testValue))
            {
                if (testValue > 0 & testValue < 4000)
                {
                    return true;
                }

                Console.WriteLine("\"{0}\t\"The Arabic numeral is outside the valid range. Valid are numbers from 1 - 3999.", inputValue);
                return false;
            }

            var successfulRomanMatch = Regex.Match(inputValue, Global.RomanNumberRegExExpression).Success;

            if (!successfulRomanMatch)
                Console.WriteLine("\"{0}\"\tIs not a valid Roman numeral and not a valid Arabic numeral.", inputValue);
            return successfulRomanMatch;
        }

        public static ConversionDirection GetConversionDirection(this string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue)) return ConversionDirection.Unknown;
            if (Regex.Match(inputValue, Global.RomanNumberRegExExpression, RegexOptions.IgnoreCase).Success)
                return ConversionDirection.ToArabic;
            if (int.TryParse(inputValue, out _))
                return ConversionDirection.ToRoman;

            return ConversionDirection.Unknown;
        }
    }


}
