using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Services
{
    public interface IFBTranslator
    {
        string Get(EFizzBuzz fizzBuzz, int number);
    }
}