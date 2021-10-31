using System.Collections.Generic;
using System.Linq;

using FizzBuzz.Server.Providers;
using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;
using FizzBuzz.Shared.Domain.Services;

namespace FizzBuzz.Server.Services
{
    /// <summary>
    /// Calculates the FizzBuzz data of a number using its registered FBCalculators and 
    /// converts them to a text using its FBTranslationService.
    /// </summary>
    public class FBService : IFBService
    {
        private readonly IFBTranslationService FBTranslationService;

        private List<IFBCalculator> FBCalculators = new List<IFBCalculator>
        {
            new ContainingFBCalculator(),
            new MultipleFBCalculator()
        };

        public FBService(IFBTranslationService fBTranslationService)
        {
            FBTranslationService = fBTranslationService;
        }

        /// <summary>
        /// Accepts a variation and a number and returns the FizzBuzz to the number 
        /// using the given variation.
        /// </summary>
        /// <param name="variation">The variation to be used to caculate the FizzBuzz data</param>
        /// <param name="max">A number to calculate the FizzBuzz data from 1 to that number</param>
        /// <returns>The FizzBuzz of the number</returns>
        public IEnumerable<string> Get(EVariation variation, int max)
        {
            IFBCalculator fBCalculator = FBCalculators
                .Single(F => (F as BaseFBCalculator).CanHandle(variation));

            return Enumerable.Range(1, max)
                .Select(N =>
                    FBTranslationService.Get(fBCalculator.Get(N), N)
                );
        }
    }
}