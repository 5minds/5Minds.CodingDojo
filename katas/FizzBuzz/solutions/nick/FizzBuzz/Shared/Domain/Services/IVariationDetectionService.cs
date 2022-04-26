using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Services
{
    /// <summary>
    /// Calculates EVariation of the given vaiation number.
    /// </summary>
    public interface IVariationDetectionService
    {
        /// <summary>
        /// Accepts a number and calculates the EVariation of it.
        /// </summary>
        /// <param name="variationNumber">A number to calculate its EVariation</param>
        /// <returns>The calculated EVariation</returns>
        EVariation Get(int variationNumber);
    }
}