using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Providers
{
    /// <summary>
    /// Calculates the FizzBuzz of a number.
    /// </summary>
    public interface IFBCalculator
    {
        /// <summary>
        /// Returns the FizzBuzz of a number
        /// </summary>
        /// <param name="number">A number to get its EFizzBuzz</param>
        /// <returns>The Calculated EFizzBuzz</returns>
        EFizzBuzz Get(int number);
    }
}