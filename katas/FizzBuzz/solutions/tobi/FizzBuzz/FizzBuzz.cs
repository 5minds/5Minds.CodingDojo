using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public interface IFizzBuzz
    {
        string ConvertNumber(int number, bool extended);
        string FizzBuzzSimple(int start = 1, int end = 100);
        string FizzBuzzVariation(int start = 1, int end = 100);
    }

    public class FizzBuzz : IFizzBuzz
    {
        public const string FizzStr = "Fizz";
        public const string BuzzStr = "Buzz";
        public const string FizzBuzzStr = "FizzBuzz";

        public string ConvertNumber(int number, bool extended)
        {
            if((number % 3 == 0 && number % 5 == 0) || (extended && number.ToString().Contains("3") && number.ToString().Contains("5")))
            {
                return FizzBuzzStr;
            }
            else if(number % 3 == 0 || (extended && number.ToString().Contains("3")))
            {
                return FizzStr;
            }
            else if(number % 5 == 0 || (extended && number.ToString().Contains("5")))
            {
                return BuzzStr;
            }

            return number.ToString();
        }

        public string FizzBuzzSimple(int start = 1, int end = 100)
        {
            var builder = new StringBuilder();

            for(var i = start; i <= end; i++)
            {
                builder.Append(ConvertNumber(i, false));
                builder.Append(",");
            }

            var result = builder.ToString().TrimEnd(',');
            return result;
        }

        public string FizzBuzzVariation(int start = 1, int end = 100)
        {
            var builder = new StringBuilder();

            for (var i = start; i <= end; i++)
            {
                builder.Append(ConvertNumber(i, true));
                builder.Append(",");
            }

            var result = builder.ToString().TrimEnd(',');
            return result;
        }
    }
}
