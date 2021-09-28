using ChangeReturn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ChangeReturn.Money;

namespace ChangeReturn.Tests
{
    [TestClass()]
    public class ChangeCalculatorTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestForExcpetionWhenChangeIsImpossible()
        {
            // that would be on 100th of a cent, which is impossible for us to return
            var result = ChangeCalculator.ReturnChange((decimal)0.0001);
            Assert.IsNull(result);
        }

        [DataTestMethod()]
        [DataRow(-0.1f)]
        [DataRow(-1f)]
        [DataRow(-10f)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForExcpetionWhenChangeIsNotPositve(float changeAmount)
        {
            var result = ChangeCalculator.ReturnChange((decimal)changeAmount);
            Assert.IsNull(result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForExcpetionWhenExistingAmountsArrayIsInvalid()
        {
            // -1 is not allowed
            decimal[] amountsArray = { 100m, 10m, -1m };

            var result = new Change();
            decimal remainingAmount = 0m;
            ChangeCalculator.AddFittingMoneyAmountsToResult(result, ref remainingAmount, amountsArray, MoneyType.EuroBill);
        }

        [TestMethod()]
        public void ReturnChangeTest00()
        {
            var expected = new Change();
            var result = ChangeCalculator.ReturnChange(0);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ReturnChangeTest01()
        {
            var expected = new Change();
            expected.ChangeMoney.Add((new Money(100, MoneyType.EuroBill), 1));
            expected.ChangeMoney.Add((new Money(20, MoneyType.EuroBill), 1));

            var result = ChangeCalculator.ReturnChange(120);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ReturnChangeTest02()
        {
            var expected = new Change();
            expected.ChangeMoney.Add((new Money(100, MoneyType.EuroBill), 2));
            expected.ChangeMoney.Add((new Money(20, MoneyType.EuroBill), 1));
            expected.ChangeMoney.Add((new Money(5, MoneyType.EuroBill), 1));

            var result = ChangeCalculator.ReturnChange(225);
            Assert.AreEqual(expected, result);
        }

        //[TestMethod()]
        //public void ReturnChangeTest03()
        //{
        //    var expected = new Change();
        //    expected.ChangeMoney.Add((new Money(100, MoneyType.EuroBill), 1));
        //    expected.ChangeMoney.Add((new Money(20, MoneyType.EuroBill), 1));
        //    expected.ChangeMoney.Add((new Money(2, MoneyType.EuroCoin), 1));
        //    expected.ChangeMoney.Add((new Money(1, MoneyType.EuroCoin), 1));
        //    expected.ChangeMoney.Add((new Money(0.2m, MoneyType.CentCoin), 2));
        //    expected.ChangeMoney.Add((new Money(0.05m, MoneyType.CentCoin), 1));

        //    var result = ChangeCalculator.ReturnChange((decimal)123.45);
        //    Assert.AreEqual(expected, result);
        //}

        [TestMethod()]
        public void ReturnChangeTest03()
        {
            var expected = new Change();
            expected.ChangeMoney.Add((new Money(100, MoneyType.EuroBill), 1));
            expected.ChangeMoney.Add((new Money(20, MoneyType.EuroBill), 1));
            expected.ChangeMoney.Add((new Money(0.5m, MoneyType.CentCoin), 6));
            expected.ChangeMoney.Add((new Money(0.2m, MoneyType.CentCoin), 2));
            expected.ChangeMoney.Add((new Money(0.05m, MoneyType.CentCoin), 1));

            var result = ChangeCalculator.ReturnChange((decimal)123.45);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ReturnChangeTest04()
        {
            var expected = new Change();
            expected.ChangeMoney.Add((new Money(0.02m, MoneyType.CentCoin), 1));
            expected.ChangeMoney.Add((new Money(0.01m, MoneyType.CentCoin), 1));

            var result = ChangeCalculator.ReturnChange((decimal)0.03);
            Assert.AreEqual(expected, result);
        }

    }
}