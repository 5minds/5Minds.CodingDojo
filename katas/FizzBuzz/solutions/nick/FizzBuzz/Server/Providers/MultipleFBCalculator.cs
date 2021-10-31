using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;

namespace FizzBuzz.Server.Providers
{
    /// <summary>
    /// A FBCalculator that functions arithmatically based of the multiples of 3 and 5.
    /// </summary>
    public class MultipleFBCalculator : BaseFBCalculator, IFBCalculator
    {
        public MultipleFBCalculator()
        {
            Variation = EVariation.Multiple;
        }

        /// <summary>
        /// Returns a EFizzBuzz of the given number as following:
        /// If the number is a multiple of both 3 and 5, returns FizzBuzz,
        /// if the number is a multiple of just 3 returns Fizz and if it is a multiple of 5, Buzz,
        /// otherwise None.
        /// </summary>
        /// <param name="number">A number to get its EFizzBuzz</param>
        /// <returns>The Calculated EFizzBuzz</returns>
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