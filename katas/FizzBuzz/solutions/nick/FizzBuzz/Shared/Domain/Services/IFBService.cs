using System.Collections.Generic;

using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Services
{
    public interface IFBService
    {
        IEnumerable<string> Get(EVariation variation, int max);
    }
}