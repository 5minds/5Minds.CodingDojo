using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;

namespace FizzBuzz.Server.Providers
{
    public class ContainingFBCalculator : BaseFBCalculator, IFBCalculator
    {
        public ContainingFBCalculator()
        {
            Variation = EVariation.Containing;
        }

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