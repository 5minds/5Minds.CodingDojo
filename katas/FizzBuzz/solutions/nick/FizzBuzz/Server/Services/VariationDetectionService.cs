using System;

using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Services;

namespace FizzBuzz.Server.Services
{
    public class VariationDetectionService : IVariationDetectionService
    {
        public EVariation Get(int variationNumber) =>
            Enum.IsDefined(typeof(EVariation), variationNumber) ?
                (EVariation)variationNumber :
                EVariation.Multiple;
    }
}