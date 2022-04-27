using System.Collections.Generic;
using System.Text;

namespace ArabicRomanKata.Converter
{
    public static class ArabicToRoman
    {
        internal static readonly Dictionary<int, string> ArabicRomanMapping = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        public static string ConvertArabicToRoman(this int numberToBeConvert)
        {
            var romanNumber = new StringBuilder();

            foreach (var (key, value) in ArabicRomanMapping)
            {
                //This works only with the defined sorted ArabicRomanMapping.
                while (numberToBeConvert >= key)
                {
                    romanNumber.Append(value);
                    numberToBeConvert -= key;
                }
            }
            return romanNumber.ToString();
        }

        #region

        #endregion
    }
}
