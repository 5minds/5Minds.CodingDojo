using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Services;

namespace FizzBuzz.Server.Services
{
    /// <summary>
    /// Calculates the equivalent text for the FizzBuzz data.
    /// </summary>
    public class FBTranslationService : IFBTranslationService
    {
        /// <summary>
        /// Accepts a number and its FizzBuzz data and returns the equivalent text.
        /// If FizzBuzz is None, returns the number itself as text.
        /// </summary>
        /// <param name="fizzBuzz">A FizzBuzz to get its text</param>
        /// <param name="number">The original number</param>
        /// <returns>Equivalent text for the FizzBuzz data</returns>
        public string Get(EFizzBuzz fizzBuzz, int number) => fizzBuzz switch
        {
            EFizzBuzz.Fizz => "Fizz",
            EFizzBuzz.Buzz => "Buzz",
            EFizzBuzz.FizzBuzz => "FizzBuzz",
            _ => number.ToString()
        };
    }
}