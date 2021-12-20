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
        public static List<object[]> FizzBuzzSimpleData = new List<object[]>()
        {
            new object[] { 1, 100, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz,16,17,Fizz,19,Buzz,Fizz,22,23,Fizz,Buzz,26,Fizz,28,29,FizzBuzz,31,32,Fizz,34,Buzz,Fizz,37,38,Fizz,Buzz,41,Fizz,43,44,FizzBuzz,46,47,Fizz,49,Buzz,Fizz,52,53,Fizz,Buzz,56,Fizz,58,59,FizzBuzz,61,62,Fizz,64,Buzz,Fizz,67,68,Fizz,Buzz,71,Fizz,73,74,FizzBuzz,76,77,Fizz,79,Buzz,Fizz,82,83,Fizz,Buzz,86,Fizz,88,89,FizzBuzz,91,92,Fizz,94,Buzz,Fizz,97,98,Fizz,Buzz" },
            new object[] { 1, 1, "1" },
            new object[] { 1, 10, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz" },
        };
        public static List<object[]> FizzBuzzVariationData = new List<object[]>()
        {
            new object[] { 1, 100, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,Fizz,14,FizzBuzz,16,17,Fizz,19,Buzz,Fizz,22,Fizz,Fizz,Buzz,26,Fizz,28,29,FizzBuzz,Fizz,Fizz,Fizz,Fizz,FizzBuzz,Fizz,Fizz,Fizz,Fizz,Buzz,41,Fizz,Fizz,44,FizzBuzz,46,47,Fizz,49,Buzz,Fizz,Buzz,FizzBuzz,Fizz,Buzz,Buzz,Fizz,Buzz,Buzz,FizzBuzz,61,62,Fizz,64,Buzz,Fizz,67,68,Fizz,Buzz,71,Fizz,Fizz,74,FizzBuzz,76,77,Fizz,79,Buzz,Fizz,82,Fizz,Fizz,Buzz,86,Fizz,88,89,FizzBuzz,91,92,Fizz,94,Buzz,Fizz,97,98,Fizz,Buzz" },
            new object[] { 1, 1, "1" },
            new object[] { 1, 10, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz" },
        };

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

        [Fact]
        public void FizzBuzzSimple_ThrowsOnInvalidData()
        {
            var fizzBuzz = new FizzBuzz();
            Assert.Throws<ArgumentException>(() => fizzBuzz.FizzBuzzSimple(10, 1));
        }

        [Fact]
        public void FizzBuzzVariation_ThrowsOnInvalidData()
        {
            var fizzBuzz = new FizzBuzz();
            Assert.Throws<ArgumentException>(() => fizzBuzz.FizzBuzzVariation(10, 1));
        }
    }
}
