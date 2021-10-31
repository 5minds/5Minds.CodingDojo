using System.Collections.Generic;
using System.Linq;

using FizzBuzz.Server.Providers;
using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;
using FizzBuzz.Shared.Domain.Services;

namespace FizzBuzz.Server.Services
{
    public class FBService : IFBService
    {
        private readonly IFBTranslator FBTranslator;

        private List<IFBCalculator> FBCalculators = new List<IFBCalculator>
        {
            new ContainsFBCalculator(),
            new MultipleFBCalculator()
        };

        public FBService(IFBTranslator fBTranslator)
        {
            FBTranslator = fBTranslator;
        }

        public IEnumerable<string> Get(EVariation variation, int max)
        {
            IFBCalculator fBCalculator = FBCalculators
                .Single(F => (F as BaseFBCalculator).CanHandle(variation));

            return Enumerable.Range(1, max)
                .Select(N =>
                    FBTranslator.Get(fBCalculator.Get(N), N)
                );
        }
    }
}