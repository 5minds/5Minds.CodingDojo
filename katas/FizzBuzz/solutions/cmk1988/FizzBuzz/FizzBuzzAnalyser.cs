using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzAnalyser
    {
        public string Analyse(int i)
        {
            var sb = new StringBuilder();
            if (i % 3 == 0 || i.ToString().Contains("3"))
                sb.Append("Fizz");
            if (i % 5 == 0 || i.ToString().Contains("5"))
                sb.Append("Buzz");
            if (string.IsNullOrEmpty(sb.ToString()))
                sb.Append(i);
            return sb.ToString();
        }

        public IEnumerable<string> AnalyseRangeFromTo(int from = 1, int to = 100)
        {
            for (int i = from; i <= to; i++)
            {
                yield return Analyse(i);
            }
        }

        public string AnalyseRangeFromToAndReturnString(int from = 1, int to = 100) => string.Join(", ", AnalyseRangeFromTo(from, to));
    }
}
