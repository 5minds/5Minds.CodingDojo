using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using TürmeVonHanoi;

namespace TürmeVonHanoiTest
{
    [TestClass]
    public class TowerOfHanoiTest
    {
        [TestMethod]
        public void CheckWinCondition_ConditionMet_ReturnsTrue()
        {
            var towerOfHanoi = new TowerOfHanoi("Tower of Hanoi test", true);            

            var checkWinConditionMethod = typeof(TowerOfHanoi).GetMethod("CheckWinCondition", BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (bool)checkWinConditionMethod.Invoke(towerOfHanoi, new object[] { });
            if (!result)
            {
                Assert.Fail("Win condition is not met for some reason!");
            }
        }

        [TestMethod]
        public void CheckWinCondition_ConditionNotMet_ReturnsFalse()
        {
            var towerOfHanoi = new TowerOfHanoi("Tower of Hanoi test");

            var checkWinConditionMethod = typeof(TowerOfHanoi).GetMethod("CheckWinCondition", BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (bool)checkWinConditionMethod.Invoke(towerOfHanoi, new object[] { });
            if (result)
            {
                Assert.Fail("Win condition is met for some reason!");
            }
        }
    }
}
