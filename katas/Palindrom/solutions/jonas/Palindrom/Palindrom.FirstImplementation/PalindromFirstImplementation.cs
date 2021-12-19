using Palindrom.Abstractions;
using System;

namespace Palindrom.FirstImplementation
{
    public class PalindromFirstImplementation : IPalindrom
    {
        public bool IsPalindrom(string inputString)
        {
            var inputStringToLower = inputString.ToLowerInvariant();
            int leftPointer = 0;
            int rightPointer = inputStringToLower.Length - 1;
            while(leftPointer < rightPointer)
            {
                while (inputStringToLower[leftPointer] < 97 || inputStringToLower[leftPointer] > 122)
                {
                    leftPointer++;
                    if (leftPointer >= inputStringToLower.Length)
                        return false;
                }
                while (inputStringToLower[rightPointer] < 97 || inputStringToLower[rightPointer] > 122)
                {
                    rightPointer--;
                    if (rightPointer == -1)
                        return false;
                }
                if (!inputStringToLower[leftPointer].Equals(inputStringToLower[rightPointer]))
                    return false;
                leftPointer++;
                rightPointer--;
            }
            return true;
        }
    }
}
