using FizzBuzz.Server.Providers;
using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Providers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Test
{
    [TestClass]
    public class MultipleFBCalculatorTest
    {
        [DataTestMethod]
        [DataRow(3)]
        [DataRow(18)]
        [DataRow(33)]
        public void TestFizz(int number)
        {
            IFBCalculator fBCalculator = new MultipleFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.Fizz);
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(25)]
        [DataRow(55)]
        public void TestBuzz(int number)
        {
            IFBCalculator fBCalculator = new MultipleFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.Buzz);
        }

        [DataTestMethod]
        [DataRow(15)]
        [DataRow(45)]
        public void TestFizzBuzz(int number)
        {
            IFBCalculator fBCalculator = new MultipleFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.FizzBuzz);
        }

        [DataTestMethod]
        [DataRow(28)]
        [DataRow(19)]
        public void TestNone(int number)
        {
            IFBCalculator fBCalculator = new MultipleFBCalculator();
            Assert.AreEqual(fBCalculator.Get(number), EFizzBuzz.None);
        }
    }
}