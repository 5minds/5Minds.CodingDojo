using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace awx2 {

    [TestClass]
    public class UtilsTest {
   
        [TestMethod]
        public void testNextBigger() {
            Assert.IsTrue(Utils.nextBigger(12) == 21);
            Assert.IsTrue(Utils.nextBigger(513) == 531);
            Assert.IsTrue(Utils.nextBigger(2017) == 2071);
            Assert.IsTrue(Utils.nextBigger(459853) == 483559);
            Assert.IsTrue(Utils.nextBigger(59884848459853) == 59884848483559);
        }

       [TestMethod]
        public void testNextBiggerNotExisting() {
            Assert.IsTrue(Utils.nextBigger(9) == -1);
            Assert.IsTrue(Utils.nextBigger(111) == -1);
            Assert.IsTrue(Utils.nextBigger(531) == -1);
        }
    }
}