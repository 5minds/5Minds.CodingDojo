using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;

namespace FizzBuzz.Server.Providers
{
    /// <summary>
    /// A FBCalculator that functions based of existence of a digit in the given number.
    /// </summary>
    public class ContainingFBCalculator : BaseFBCalculator, IFBCalculator
    {
        public ContainingFBCalculator()
        {
            Variation = EVariation.Containing;
        }

        /// <summary>
        /// Returns a EFizzBuzz based of the existence of a  digit in the given number.
        /// If the number contains both 3 and 5, returns FizzBuzz,
        /// if the number contains just 3 returns Fizz and if it contains 5, Buzz,
        /// otherwise None.
        /// </summary>
        /// <param name="number">A number to get its EFizzBuzz</param>
        /// <returns>The Calculated EFizzBuzz</returns>
        public EFizzBuzz Get(int number)
        {
            string numberText = $"{number}";
            bool contains3 = numberText.Contains("3");
            bool contains5 = numberText.Contains("5");

            if (contains3 && contains5)
                return EFizzBuzz.FizzBuzz;

            if (contains3)
                return EFizzBuzz.Fizz;

            if (contains5)
                return EFizzBuzz.Buzz;

            return EFizzBuzz.None;
        }
    }
}