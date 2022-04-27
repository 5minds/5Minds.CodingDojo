using ChangeReturnKata.BusinessObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChangeReturnUnitTest
{
    [TestClass]
    public class ChangeReturnTest
    {
        [TestMethod]
        public void TestChange()
        {
            var changeTest = new Change(new decimal(.01));
            Assert.AreEqual(1, changeTest.OneCent);
            changeTest = new Change(new decimal(.02));
            Assert.AreEqual(1,changeTest.TwoCent);
            changeTest = new Change(new decimal(.05));
            Assert.AreEqual(1, changeTest.FiveCent);
            changeTest = new Change(new decimal(.10));
            Assert.AreEqual(1, changeTest.TenCent);
            changeTest = new Change(new decimal(.20));
            Assert.AreEqual(1, changeTest.TwentyCent);
            changeTest = new Change(new decimal(.50));
            Assert.AreEqual(1, changeTest.FiftyCent);
            changeTest = new Change(new decimal(1.0));
            Assert.AreEqual(2, changeTest.FiftyCent);
            changeTest = new Change(new decimal(10.0));
            Assert.AreEqual(1, changeTest.TenEuro);
            changeTest = new Change(new decimal(20.0));
            Assert.AreEqual(1, changeTest.TwentyEuro);
            changeTest = new Change(new decimal(50.0));
            Assert.AreEqual(1, changeTest.FiftyEuro);
            changeTest = new Change(new decimal(100.0));
            Assert.AreEqual(1, changeTest.HundredEuro);
            changeTest = new Change(new decimal(111.11));
            Assert.AreEqual(1, changeTest.OneCent);
            Assert.AreEqual(1, changeTest.TenCent);
            Assert.AreEqual(2, changeTest.FiftyCent);
            Assert.AreEqual(1, changeTest.TenEuro);
            Assert.AreEqual(1, changeTest.HundredEuro);
            Assert.AreEqual(0, changeTest.TwoCent);
            Assert.AreEqual(0, changeTest.FiveCent);
            Assert.AreEqual(0, changeTest.TwentyCent);
            Assert.AreEqual(0, changeTest.FiveEuro);
            Assert.AreEqual(0, changeTest.TwentyEuro);
            Assert.AreEqual(0, changeTest.FiftyEuro);
        }
    }
}
