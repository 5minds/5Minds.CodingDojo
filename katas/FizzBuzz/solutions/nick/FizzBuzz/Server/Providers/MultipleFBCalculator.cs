using System;

using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;

namespace FizzBuzz.Server.Providers
{
    public class MultipleFBCalculator : IFBCalculator
    {
      
        EFizzBuzz IFBCalculator.Get(int number)
        {
            bool multiple3 = number % 3 == 0;
            bool multiple5 = number % 5 == 0;

            if (multiple3 && multiple5)
                return EFizzBuzz.FizzBuzz;

            if (multiple3)
                return EFizzBuzz.Fizz;

            if (multiple5)
                return EFizzBuzz.Buzz;

            return EFizzBuzz.None;
        }
    }
}