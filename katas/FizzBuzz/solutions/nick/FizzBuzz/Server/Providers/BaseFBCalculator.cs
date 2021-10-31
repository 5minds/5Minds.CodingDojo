using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Server.Providers
{
    public abstract class BaseFBCalculator
    {
        public EVariation Variation { get; set; }

        public bool CanHandle(EVariation variation) => variation == Variation;
    }
}