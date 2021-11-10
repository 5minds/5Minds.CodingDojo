using NextBiggerNumber.Abstractions;
using System;
using System.Collections.Generic;

namespace NextBiggerNumber.FirstImplementation
{
    public class NextBiggerNumberFirstImplementation : INextBiggerNumber
    {
        public int NextBigger(int number)
        {
            var asString = number.ToString();
            var asNewString = string.Create(asString.Length, asString, (span, value) =>
            {
                value.AsSpan().CopyTo(span);
                int swapIndex = -1;
                for (var i = span.Length - 1; i >= 1; i--)
                {
                    if(span[i] > span[i - 1])
                    {
                        swapIndex = i - 1;
                        break;
                    }
                }
                if (swapIndex == -1)
                    return;
                int biggestIndex = swapIndex + 1;
                for (var i = span.Length - 1; i > biggestIndex; i--)
                {
                    if (span[i] > span[swapIndex] && span[i] < span[biggestIndex])
                    {
                        biggestIndex = i;
                    }
                }
                (span[swapIndex], span[biggestIndex]) = (span[biggestIndex], span[swapIndex]);
                MemoryExtensions.Sort(span.Slice(swapIndex + 1));
            });
            return asString.Equals(asNewString) ? -1 : int.Parse(asNewString);
        }
    }
}
