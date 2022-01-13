namespace NextBiggerNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Numbers
    {
        /// <summary>
        /// Gets the next bigger number with the same digits.
        /// </summary>
        /// <returns>The next bigger number or -1 when it is impossible to find a bigger number.</returns>
        /// <param name="nNumber">Number.</param>
        public static long GetNextBiggerNumber(long nNumber)
        {
            List<Byte> lstDigits = nNumber.ToString().Select(x => Convert.ToByte(x.ToString())).ToList();
            List<Byte> lstLowerDigits = new List<Byte>();

            if (lstDigits.Count < 2 || nNumber < 0)
            {
                return -1L;
            }
            // loop over digits from least to most significant digit
            for (int index = lstDigits.Count - 1; index > 0; index--)
            {
                lstLowerDigits.Add(lstDigits[index]);
                // compare higher significant digit with lower one to find pivot digit
                if (lstDigits[index - 1] < lstDigits[index])
                {
                    // sort right digits to find the smallest one above a pivot value
                    lstLowerDigits.Sort();
                    // find the smallest but bigger than the pivot for swapping
                    int nDigitToSwapIndex = lstLowerDigits.FindIndex(Value => Value > lstDigits[index - 1]);
                    // push pivot digit to lower significant digits
                    lstLowerDigits.Add(lstDigits[index - 1]);
                    // swap 
                    lstDigits[index - 1] = lstLowerDigits.ElementAt(nDigitToSwapIndex);
                    lstLowerDigits.RemoveAt(nDigitToSwapIndex);
                    // replace the least significant digigits by
                    // removing
                    lstDigits.RemoveRange(index, lstDigits.Count - index);
                    // sorting
                    lstLowerDigits.Sort();
                    // and readding
                    lstDigits.AddRange(lstLowerDigits);
                    // build proper return value 
                    long nResult = lstDigits.Select((Value, Index) => Value * Convert.ToInt64(Math.Pow(10, lstDigits.Count - Index - 1))).Sum();
                    return nResult;
                }

            }
            return -1L;
        }
    }
}
