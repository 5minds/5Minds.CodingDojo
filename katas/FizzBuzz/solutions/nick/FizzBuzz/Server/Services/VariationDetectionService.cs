using System;

using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Services;

namespace FizzBuzz.Server.Services
{
    /// <summary>
    /// Calculates EVariation of the given vaiation number.
    /// </summary>
    public class VariationDetectionService : IVariationDetectionService
    {
        /// <summary>
        /// Accepts a number and calculates the EVariation of it.
        /// </summary>
        /// <param name="variationNumber">A number to calculate its EVariation</param>
        /// <returns>The calculated EVariation</returns>
        public EVariation Get(int variationNumber) =>
            Enum.IsDefined(typeof(EVariation), variationNumber) ?
                (EVariation)variationNumber :
                EVariation.Multiple;
    }
}