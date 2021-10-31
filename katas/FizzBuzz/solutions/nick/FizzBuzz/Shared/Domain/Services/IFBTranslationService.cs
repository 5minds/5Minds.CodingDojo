using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Services
{
    /// <summary>
    /// Calculates the equivalent text for the FizzBuzz data.
    /// </summary>
    public interface IFBTranslationService
    {
        /// Accepts a variation and a number and returns the FizzBuzz to the number 
        /// using the given variation.
        /// </summary>
        /// <param name="variation">The variation to be used to caculate the FizzBuzz data</param>
        /// <param name="max">A number to calculate the FizzBuzz data from 1 to that number</param>
        /// <returns>The FizzBuzz of the number</returns>
        string Get(EFizzBuzz fizzBuzz, int number);
    }
}