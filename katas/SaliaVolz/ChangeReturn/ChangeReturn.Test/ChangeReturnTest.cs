using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChangeReturn;
using System; 

namespace ChangeReturn.Test
{
    [TestClass]
    public class ChangeReturnTest
    {
        [TestMethod]
        [DataRow(9, 10, new double[] { 0.5, 0.5 })]
        [DataRow(900, 1000, new double[] {100})]
        [DataRow(1, 186.88, new double[] {100, 50, 20, 10, 5, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 })]
        public void ReturnRightChange(double cost, double paid, double[] change)
        {
            
            List<decimal> calculatedChange = ChangeReturn.CalculateChange(Convert.ToDecimal(cost), Convert.ToDecimal(paid));

            CollectionAssert.AreEqual(change, Array.ConvertAll(calculatedChange.ToArray(), x => (double)x));
        }

        [TestMethod]
        [DataRow(9, 10.5)]
        [DataRow(1, 186.88)]
        public void ReturnRightOrder(double cost, double paid)
        {
            
            List<decimal> calculatedChange = ChangeReturn.CalculateChange(Convert.ToDecimal(cost), Convert.ToDecimal(paid));

            decimal lastChange = 0;
            bool rightorder = true;
            foreach (decimal singeChange in calculatedChange)
            {
                if(lastChange != 0 && lastChange < singeChange){
                    rightorder = false;
                }
                lastChange = singeChange;
            }

            Assert.IsTrue(rightorder);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(10, 9)]
        [DataRow(10000, 1)]
        [DataRow(1.1, 1)]
        [DataRow(1.001, 1)]
        public void NotPaidEnough(double cost, double paid)
        {
            List<decimal> calculatedChange = ChangeReturn.CalculateChange(Convert.ToDecimal(cost), Convert.ToDecimal(paid));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(9, 9.001)]
        [DataRow(1, 10000.00001)]
        [DataRow(10000, 10000.001)]
        public void NoCompatibleChange(double cost, double paid)
        {
            List<decimal> calculatedChange = ChangeReturn.CalculateChange(Convert.ToDecimal(cost), Convert.ToDecimal(paid));
        }
    }
}
