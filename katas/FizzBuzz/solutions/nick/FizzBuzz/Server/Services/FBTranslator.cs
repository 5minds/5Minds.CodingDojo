using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Services;

namespace FizzBuzz.Server.Services
{
    public class FBTranslator : IFBTranslator
    {
        public string Get(EFizzBuzz fizzBuzz, int number) => fizzBuzz switch
        {
            EFizzBuzz.Fizz => "Fizz",
            EFizzBuzz.Buzz => "Buzz",
            EFizzBuzz.FizzBuzz => "FizzBuzz",
            _ => number.ToString()
        };
    }
}