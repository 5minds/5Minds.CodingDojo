using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Services
{
    public interface IVariationDetectionService
    {
        EVariation Get(int variationNumber);
    }
}