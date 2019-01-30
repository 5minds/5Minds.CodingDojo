using System;
using System.Collections.Generic;
using System.Linq;

namespace NextBigger
{
  /// <summary>
  /// Class to find for a given number the next greater number with the same set of digits.
  /// </summary>
  public class NextBiggerNumber
  {
    /// <summary>
    /// Finds the smallest number that has the same digits as the given number and is greater than this.
    /// </summary>
    /// <param name="number">The given number</param>
    /// <returns>The next bigger number if possible, otherwise -1</returns>
    public long FindNextBiggerNumber(long number)
    {
      int[] digits = GetDigits(number);
      var numberOfDigits = digits.Length;

      // Travers the number from rightmost digit and find the first digit that is smaller than the digit next to it.
      var smallestDigitIndex = FindSmallestDigitIndex(digits);

      // If no digit is found, then all digits are sorted in descending order. In this case there cannot be a greater number.
      if (smallestDigitIndex == -1)
      {
        return smallestDigitIndex;
      }

      // Find the smallest digit on the right side that is greater than the current smallest digit.
      var nextBiggerDigitIndex = FindNextBiggerDigitIndex(digits, smallestDigitIndex);

      // Swap the above found two digits.
      SwapDigits(digits, smallestDigitIndex, nextBiggerDigitIndex);

      // Sort all digits from position next to the smallest digit to the end of the number.
      var digitSortIndex = smallestDigitIndex + 1;
      var digitSortLength = numberOfDigits - digitSortIndex;

      Array.Sort(digits, digitSortIndex, digitSortLength);

      // Convert the array of digits to a number.
      var result = digits.Select((item, index) => item * Convert.ToInt64(Math.Pow(10, digits.Length - index - 1))).Sum();

      return result;
    }

    /// <summary>
    /// Creates an array of digits from the given number.
    /// </summary>
    /// <param name="number">The given number.</param>
    /// <returns>An array of digits. </returns>
    private int[] GetDigits(long number)
    {
      List<int> listOfDigits = new List<int>();

      while (number > 0)
      {
        listOfDigits.Add(Convert.ToInt32(number % 10));
        number = number / 10;
      }

      listOfDigits.Reverse();

      return listOfDigits.ToArray();
    }

    /// <summary>
    /// Finds the first digit in the given array that is smaller than the digit next to it. 
    /// </summary>
    /// <param name="digits">The given array of digits.</param>
    /// <returns>The index if found, otherwise -1.</returns>
    private int FindSmallestDigitIndex(int[] digits)
    {
      var result = -1;
      var numberOfDigits = digits.Length;

      for (int i = numberOfDigits - 1; i > 0; i--)
      {
        if (digits[i] > digits[i - 1])
        {
          result = i - 1;
          break;
        }
      }

      return result;
    }

    /// <summary>
    /// Finds the smallest digit in the given array that is greater than the digit from the given start index.
    /// </summary>
    /// <param name="digits">The given array of digits.</param>
    /// <param name="startDigitIndex">The start index.</param>
    /// <returns>The found index.</returns>
    private int FindNextBiggerDigitIndex(int[] digits, int startDigitIndex)
    {
      var result = startDigitIndex + 1;
      var numberOfDigits = digits.Length;

      for (int i = result + 1; i < numberOfDigits; i++)
      {
        if (digits[i] > digits[startDigitIndex] && digits[i] < digits[result])
        {
          result = i;
        }
      }

      return result;
    }

    /// <summary>
    /// Swap two digits in the given array.
    /// </summary>
    /// <param name="digits">The array of digits.</param>
    /// <param name="firstDigitIndex">The index of the first digit.</param>
    /// <param name="secondDigitIndex">The index of the second digit.</param>
    private void SwapDigits(int[] digits, int firstDigitIndex, int secondDigitIndex)
    {
      var temp = digits[firstDigitIndex];
      digits[firstDigitIndex] = digits[secondDigitIndex];
      digits[secondDigitIndex] = temp;
    }

  }
}