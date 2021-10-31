using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Providers
{
    public interface IFBCalculator
    {
        EFizzBuzz Get(int number);
    }
}