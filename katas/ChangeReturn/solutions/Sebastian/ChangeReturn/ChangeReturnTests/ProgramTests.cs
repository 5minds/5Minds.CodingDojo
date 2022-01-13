using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeReturn;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeReturn.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [DataTestMethod()]
        [DataRow("1")]
        [DataRow("100")]
        [DataRow("111,22")]
        [DataRow("111.22")]
        [DataRow("1234,56")]
        [DataRow("1234.56")]
        [DataRow("0,11")]
        [DataRow("0.2")]
        public void TestValidInputs(string input)
        {
            var result = Program.ValidateInput(input);
            Assert.IsTrue(result);
        }

        [DataTestMethod()]
        [DataRow("1.000,11")]
        [DataRow("1,000.11")]
        [DataRow("1,1,1")]
        public void TestInvalidInputs(string input)
        {
            var result = Program.ValidateInput(input);
            Assert.IsFalse(result);
        }

        [DataTestMethod()]
        [DataRow("1", 1f)]
        [DataRow("100", 100f)]
        [DataRow("111,22", 111.22f)]
        [DataRow("111.22", 111.22f)]
        [DataRow("1234,56", 1234.56f)]
        [DataRow("1234.56", 1234.56f)]
        [DataRow("0,11", 0.11f)]
        [DataRow("0.2", 0.2f)]
        public void TestInputConversion(string input, float expected)
        {
            var result = Program.ConvertInput(input);
            Assert.AreEqual((decimal)expected, result);
        }

    }
}