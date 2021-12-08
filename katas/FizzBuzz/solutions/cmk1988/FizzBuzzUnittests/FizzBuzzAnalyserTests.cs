using FizzBuzz;
using System;
using Xunit;

namespace FizzBuzzUnittests
{
    public class FizzBuzzAnalyserTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(16, "16")]
        [InlineData(56, "Buzz")]
        [InlineData(31, "Fizz")]
        [InlineData(53, "FizzBuzz")]
        public void AnalyseTest(int input, string expected)
        {
            // Arrange
            var sut = new FizzBuzzAnalyser();

            // Act
            var actual = sut.Analyse(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AnalyseRangeFromToTest()
        {
            // Arrange
            var expected = new[]
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "Fizz", "14", "FizzBuzz", "16"
            };
            var sut = new FizzBuzzAnalyser();

            // Act
            var actual = sut.AnalyseRangeFromTo(1, 16);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AnalyseRangeFromToAndReturnString()
        {
            // Arrange
            var expected = "1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, Fizz, 14, FizzBuzz, 16";
            var sut = new FizzBuzzAnalyser();

            // Act
            var actual = sut.AnalyseRangeFromToAndReturnString(1, 16);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
