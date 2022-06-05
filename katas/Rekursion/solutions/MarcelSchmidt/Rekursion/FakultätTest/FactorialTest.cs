using Fakultät;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakultätTest
{
    [TestClass]
    public class FactorialTest
    {
        [TestMethod]
        public void CalculateFactorial_5Is120_ReturnsTrue()
        {
            var result = Factorial.CalculateFactorial(5);
            if (result != 120)
            {
                Assert.Fail("Factorial of result {0} is not {1} but {2} which is wrong.", 5, 120, result);
            }
        }

        [TestMethod]
        public void CalculateFactorial_9Is362880_ReturnsTrue()
        {
            var result = Factorial.CalculateFactorial(9);
            if (result != 362880)
            {
                Assert.Fail("Factorial result of {0} is not {1} but {2} which is wrong.", 9, 362880, result);
            }
        }

        [TestMethod]
        public void CalculateFactorial_1Is1_ReturnsTrue()
        {
            var result = Factorial.CalculateFactorial(1);
            if (result != 1)
            {
                Assert.Fail("Factorial result of {0} is not {1} but {2} which is wrong.", 1, 1, result);
            }
        }

        [TestMethod]
        public void CalculateFactorial_0Is1_ReturnsTrue()
        {
            var result = Factorial.CalculateFactorial(0);
            if (result != 1)
            {
                Assert.Fail("Factorial result of {0} is not {1} but {2} which is wrong.", 0, 1, result);
            }
        }

        [TestMethod]
        public void CalculateFactorial_3Is1231321_ReturnsFalse()
        {
            var result = Factorial.CalculateFactorial(3);
            if (result == 1231321)
            {
                Assert.Fail("Factorial result of {0} is not {1}.", 3, 1231321);
            }
        }
    }
}
