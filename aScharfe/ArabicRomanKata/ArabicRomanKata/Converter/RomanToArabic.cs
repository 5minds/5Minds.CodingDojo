using System.Collections.Generic;

namespace ArabicRomanKata.Converter
{
    public static class RomanToArabic
    {
        internal static readonly Dictionary<char, int> RomanArabicMapping = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="romanNumber"></param>
        /// <returns></returns>
        public static int ConvertRomanToArabic(this string romanNumber)
        {
            var arabicResult = 0;
            var previousRoman = char.MinValue;
            
            foreach (var currentRoman in romanNumber.ToUpper())
            {
                var previousValue = previousRoman == char.MinValue ? char.MinValue : RomanArabicMapping[previousRoman];
                var currentValue = RomanArabicMapping[currentRoman];

                // Consideration of the subtraction rules
                if (previousValue != 0 && currentValue > previousValue)
                {
                    // Subtraction rule
                    arabicResult = arabicResult - (2 * previousValue) + currentValue;
                }
                else
                {
                    arabicResult += currentValue;
                }
                previousRoman = currentRoman;
            }
            return arabicResult;
        }
    }
}
