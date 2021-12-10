using System;
using System.Linq;

namespace NextGreaterNumber
{
    public class NextGreaterNumber
    {
        internal long FindNextGreaterNumber(long number)
        {
            try
            {
                int index;
                
                // 1. create an array from the number that's passed in
                var array = number.ToString().Select(digit => long.Parse
                    (digit.ToString())).ToArray();

                var length = array.Length;

                // 2. from right to left, find first digit 
                // that's smaller than its left neighbour
                for (index = length - 1; index > 0; --index)
                {
                    if (array[index] > array[index - 1]) break;
                }

                if (index is 0) return -1; // start of array, cannot proceed

                var smallerDigit = array[index - 1];
                var minimum = index;

                // 3. from left to right, find smallest digit that is greater than smallerDigit
                for (var j = index + 1; j < length; ++j)
                {
                    if (array[j] > smallerDigit && array[j] < array[minimum])
                        minimum = j;
                }

                // 4. swap these two

                SwapPositions(array, index - 1, minimum);

                // 5. sort ascending after swap from swapped position to end of array

                Array.Sort(array, index, length-index);

                // construct an int from array
                var result = array.Aggregate((result, digit) => result * 10 + digit);

                return (result > 0 ? result : -1); 
            }
            catch (Exception e) // Parse, Sort, Aggregate can throw exceptions - catch any for simplicity
            {
                Console.WriteLine($"{e.Message}");
                return -1;
            }
        }

        private static void SwapPositions(long[] array, int first, int second) => 
            (array[first], array[second]) = (array[second], array[first]);
    }
}