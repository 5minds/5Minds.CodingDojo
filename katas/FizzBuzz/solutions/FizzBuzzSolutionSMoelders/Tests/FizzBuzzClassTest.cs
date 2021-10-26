using FizzBuzzSolutionSMoelders.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FizzBuzzClassTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestableMaintainableFizzBuzzClass TestClass = new TestableMaintainableFizzBuzzClass();
            int[] TestArray = TestClass.TestableMaintainableSolver(1, 15);
            // Index 0 = FizzBuzz || New chosen name
            // We are expecting 1 count of FizzBuzz at value = 15.
            Assert.AreEqual(TestArray[0], 1);

            // Index 0 = FizzBuzz || New chosen name
            // We are expecting 1 count of FizzBuzz at value = 15.
            Assert.AreNotEqual(TestArray[0], 2);

        }

        [TestMethod]
        public void TestMethod2()
        {
            TestableMaintainableFizzBuzzClass TestClass = new TestableMaintainableFizzBuzzClass();
            int[] TestArray = TestClass.TestableMaintainableSolver(1, 15);
            // Index 1 = Fizz || New chosen name
            // We are expecting 4 counts of Fizz at value = 3, 6, 9, 12.
            Assert.AreEqual(TestArray[1], 4);

            // Index 1 = Fizz || New chosen name
            // We are expecting 4 counts of Fizz at value = 3, 6, 9, 12.
            Assert.AreNotEqual(TestArray[1], 7);

        }

        [TestMethod]
        public void TestMethod3()
        {
            TestableMaintainableFizzBuzzClass TestClass = new TestableMaintainableFizzBuzzClass();
            int[] TestArray = TestClass.TestableMaintainableSolver(1, 15);
            // Index 2 = Buzz || New chosen name
            // We are expecting 2 counts of Buzz at value = 5, 10.
            Assert.AreEqual(TestArray[2], 2);

            // Index 2 = Buzz || New chosen name
            // We are expecting 2 counts of Buzz at value = 5, 10.
            Assert.AreNotEqual(TestArray[2], 3);

        }

        [TestMethod]
        public void TestMethod4()
        {
            FizzBuzzSolutionSMoelders.StandardFizzBuzzClass TestClass = new FizzBuzzSolutionSMoelders.StandardFizzBuzzClass();

            Assert.IsTrue(TestClass.FizzBuzzCheck(15));
            Assert.IsTrue(TestClass.FizzBuzzCheck(30));
            Assert.IsTrue(TestClass.FizzBuzzCheck(45));
            Assert.IsTrue(TestClass.FizzBuzzCheck(60));
            Assert.IsTrue(TestClass.FizzBuzzCheck(75));

            Assert.IsFalse(TestClass.FizzBuzzCheck(3));
            Assert.IsFalse(TestClass.FizzBuzzCheck(5));
            Assert.IsFalse(TestClass.FizzBuzzCheck(7));
            Assert.IsFalse(TestClass.FizzBuzzCheck(11));
            Assert.IsFalse(TestClass.FizzBuzzCheck(66));
        }

        [TestMethod]
        public void TestMethod5()
        {
            FizzBuzzSolutionSMoelders.StandardFizzBuzzClass TestClass = new FizzBuzzSolutionSMoelders.StandardFizzBuzzClass();

            Assert.IsTrue(TestClass.BuzzCheck(5));
            Assert.IsTrue(TestClass.BuzzCheck(10));
            Assert.IsTrue(TestClass.BuzzCheck(20));
            Assert.IsTrue(TestClass.BuzzCheck(25));
            Assert.IsTrue(TestClass.BuzzCheck(50));

            Assert.IsFalse(TestClass.BuzzCheck(1));
            Assert.IsFalse(TestClass.BuzzCheck(2));
            Assert.IsFalse(TestClass.BuzzCheck(4));
            Assert.IsFalse(TestClass.BuzzCheck(16));
            Assert.IsFalse(TestClass.BuzzCheck(58));
        }

        [TestMethod]
        public void TestMethod6()
        {
            FizzBuzzSolutionSMoelders.StandardFizzBuzzClass TestClass = new FizzBuzzSolutionSMoelders.StandardFizzBuzzClass();

            Assert.IsTrue(TestClass.FizzCheck(3));
            Assert.IsTrue(TestClass.FizzCheck(6));
            Assert.IsTrue(TestClass.FizzCheck(9));
            Assert.IsTrue(TestClass.FizzCheck(66));
            Assert.IsTrue(TestClass.FizzCheck(99));

            Assert.IsFalse(TestClass.FizzCheck(4));
            Assert.IsFalse(TestClass.FizzCheck(7));
            Assert.IsFalse(TestClass.FizzCheck(8));
            Assert.IsFalse(TestClass.FizzCheck(44));
            Assert.IsFalse(TestClass.FizzCheck(100));
        }
    }
}
