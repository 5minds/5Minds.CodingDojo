using FizzBuzz.Server.Providers;
using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Test
{
    [TestClass]
    public class ContainingFBCalculatorTest
    {
        [DataTestMethod]
        [DataRow(37)]
        [DataRow(13)]
        [DataRow(33)]
        public void TestFizz(int number)
        {
            IFBCalculator fBCalculator = new ContainingFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.Fizz);
        }

        [DataTestMethod]
        [DataRow(59)]
        [DataRow(25)]
        [DataRow(55)]
        public void TestBuzz(int number)
        {
            IFBCalculator fBCalculator = new ContainingFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.Buzz);
        }

        [DataTestMethod]
        [DataRow(53)]
        [DataRow(35)]
        public void TestFizzBuzz(int number)
        {
            IFBCalculator fBCalculator = new ContainingFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.FizzBuzz);
        }

        [DataTestMethod]
        [DataRow(28)]
        [DataRow(1)]
        public void TestNone(int number)
        {
            IFBCalculator fBCalculator = new ContainingFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.None);
        }
    }
}