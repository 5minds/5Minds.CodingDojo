using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Services
{
    public interface IFBTranslationService
    {
        string Get(EFizzBuzz fizzBuzz, int number);
    }
}