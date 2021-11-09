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
        public string ConvertNumber(int number, bool extended)
        {
            throw new NotImplementedException();
        }

        public string FizzBuzzSimple(int start = 1, int end = 100)
        {
            throw new NotImplementedException();
        }

        public string FizzBuzzVariation(int start = 1, int end = 100)
        {
            throw new NotImplementedException();
        }
    }
}
