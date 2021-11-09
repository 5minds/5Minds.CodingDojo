using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        public static List<object[]> ConvertNumberData = new List<object[]>() 
        {
            new object[] { 3, false, "Fizz" },
            new object[] { 5, false, "Buzz" },
            new object[] { 15, false, "FizzBuzz" },
            new object[] { 3, true, "Fizz" },
            new object[] { 5, true, "Buzz" },
            new object[] { 15, true, "FizzBuzz" },
            new object[] { 13, false, "13" },
            new object[] { 13, true, "Fizz" },
            new object[] { 52, false, "52" },
            new object[] { 52, true, "Buzz" },
            new object[] { 53, false, "53" },
            new object[] { 53, true, "FizzBuzz" },
            new object[] { 14, false, "14" },
            new object[] { 14, true, "14" },
        };
        public static List<object[]> FizzBuzzSimpleData = new List<object[]>();
        public static List<object[]> FizzBuzzVariationData = new List<object[]>();

        [Theory]
        [MemberData(nameof(ConvertNumberData))]
        public void ConvertNumber_ReturnsCorrectResult(int number, bool extended, string expectedResult)
        {
            var fizzBuzz = new FizzBuzz();
            var result = fizzBuzz.ConvertNumber(number, extended);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(FizzBuzzSimpleData))]
        public void FizzBuzzSimple_ReturnsCorrectResult(int start, int end, string expectedResult)
        {
            var fizzBuzz = new FizzBuzz();
            var result = fizzBuzz.FizzBuzzSimple(start, end);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(FizzBuzzVariationData))]
        public void FizzBuzzVariation_ReturnsCorrectResult(int start, int end, string expectedResult)
        {
            var fizzBuzz = new FizzBuzz();
            var result = fizzBuzz.FizzBuzzVariation(start, end);
            Assert.Equal(expectedResult, result);
        }
    }
}
