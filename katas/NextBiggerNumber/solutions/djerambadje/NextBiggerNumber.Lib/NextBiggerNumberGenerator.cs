using System;
using System.Linq;

namespace NextBiggerNumber.Lib
{
    public class NextBiggerNumberGenerator
    {
        
        private Func<long, int> GetLength = (number) => number.ToString().Length;
        
        private Func<long, char[]> ConvertToDigits = (number) => number.ToString().ToCharArray();

        private Action<char[],int,int> PartialArraySort = (digits, startPosition, endPosition) =>  digits.Skip(startPosition).Take(endPosition - startPosition + 1).OrderBy(o => o).ToArray().CopyTo(digits, startPosition);
               

        private Predicate<long> AreDigitsAscendingSorted = (number) => number.ToString().Select(o => o).SequenceEqual(number.ToString().OrderBy(o => o));
        
        private Predicate<long> AreDigitsDescendingSorted = (number) => number.ToString().Select(o => o).SequenceEqual(number.ToString().OrderByDescending(o => o));
     
        private Action<char[], int, int> swap = (digits, i, j) =>
        {
            var temp = digits[i];
            digits[i] = digits[j];
            digits[j] = temp;
        };

        private Func<char[], long> ConvertToLong = (digits) => long.Parse(new string(digits));

        public long NextBigger(long number)
        {
            int i;
            var digits = ConvertToDigits(number);
            var digitsLength = GetLength(number);

            if (AreDigitsDescendingSorted(number) || digitsLength == 1)
            {
                return -1;
            }

            if (AreDigitsAscendingSorted(number))
            {
                swap(digits, digitsLength - 1, digitsLength - 2);
                return ConvertToLong(digits);
            }

            for (i = digitsLength - 1; i > 0; i--)
                if (digits[i] > digits[i - 1])
                    break;

            int smallestPosition = i,smallestDigitTotheNext = digits[i - 1];

            for (int j = i + 1; j < digitsLength; j++)
                if (digits[j] > smallestDigitTotheNext && digits[j] < digits[smallestPosition])
                    smallestPosition = j;

            swap(digits, smallestPosition, i - 1);

            PartialArraySort(digits, i, digitsLength -1);

            return ConvertToLong(digits);
        }
    }
}
