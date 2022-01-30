using System;
using System.Collections.Generic;
using System.Linq;

namespace _5Minds.Services
{
    /// <summary>
    /// Represents the digit service for solving problems regarding digits.
    /// </summary>
    public class DigitService
    {
        /// <summary>
        /// Gets the next bigger number of a specified number.
        /// </summary>
        /// <param name="n">a number with long type.</param>
        /// <returns>Returns the next bigger number if found, otherwise -1.</returns>
        public static long GetNextBigger(long n)
        {
            string numExpression = n.ToString();
            int numLength = numExpression.Length;
            int idx = numLength;
            List<long> digits = numExpression.Select(c => (long)(c -'0')).ToList();

            while (--idx >= 0)
            {
                List<long> lastDigitList = digits.Skip(idx).Take(numLength - idx).ToList();

                if (lastDigitList.Count <= 1)
                {
                    continue;
                }

                if (lastDigitList.Count == 2)
                {
                    // Combine all pre digits with two ordered digits to find the next bigger number. 
                    // e.g. 12 => 21
                    long nextBiggerNum = long.Parse(string.Join(string.Empty, digits.Take(idx).Union(lastDigitList.OrderByDescending(d => d))));

                    if (nextBiggerNum > n)
                    {
                        return nextBiggerNum;
                    }
                }
                else
                {
                    /*
                     * if the number of last digits is greater than 2, find the largest second digit
                     * and then order by remaining digits by ascending and eventually check the next bigger number.
                     * e.g. 85395 => 83559.
                     */

                    // Find the second largest digit.
                    long secondLargestDigit = lastDigitList.OrderByDescending(d => d).ElementAt(1);

                    List<long> digitsList = new List<long>();
                    bool isLargestSecondDigitFound = false;

                    // Create a new digit list from the last digit list except second largest digit.
                    foreach (long lastDigit in lastDigitList)
                    {
                        if (!isLargestSecondDigitFound && lastDigit == secondLargestDigit)
                        {
                            isLargestSecondDigitFound = true;
                        }
                        else
                        {
                            digitsList.Add(lastDigit);
                        }
                    }

                    // Order by ascending for the digit list.
                    digitsList = digitsList.OrderBy(d => d).ToList();

                    // Insert the second largest digit at the zero index.
                    digitsList.Insert(0, secondLargestDigit);

                    // Insert all previous digits at the zero index.
                    digitsList.InsertRange(0, digits.Take(idx));

                    long nextBiggerNum = long.Parse(string.Join(string.Empty, digitsList));

                    if (nextBiggerNum > n)
                    {
                        return nextBiggerNum;
                    }
                }
            }

            return -1;
        }
    }
}
