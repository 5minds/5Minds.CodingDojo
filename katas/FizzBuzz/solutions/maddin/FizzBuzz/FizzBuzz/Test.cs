using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestFizz()
        {
            var fizzBuzz = new FizzBuzz();

            Assert.IsTrue(fizzBuzz.IsFizz(3));
            Assert.IsTrue(fizzBuzz.IsFizz(6));
            Assert.IsTrue(fizzBuzz.IsFizz(15));
            Assert.IsTrue(fizzBuzz.IsFizz(30));
            Assert.IsTrue(fizzBuzz.IsFizz(42));
            Assert.IsTrue(fizzBuzz.IsFizz(66));

            Assert.IsFalse(fizzBuzz.IsFizz(0));
            Assert.IsFalse(fizzBuzz.IsFizz(5));
            Assert.IsFalse(fizzBuzz.IsFizz(22));
        }

        [TestMethod]
        public void TestBuzz()
        {
            var fizzBuzz = new FizzBuzz();

            Assert.IsTrue(fizzBuzz.IsBuzz(5));
            Assert.IsTrue(fizzBuzz.IsBuzz(10));
            Assert.IsTrue(fizzBuzz.IsBuzz(15));
            Assert.IsTrue(fizzBuzz.IsBuzz(30));
            Assert.IsTrue(fizzBuzz.IsBuzz(45));
            Assert.IsTrue(fizzBuzz.IsBuzz(105));

            Assert.IsFalse(fizzBuzz.IsBuzz(0));
            Assert.IsFalse(fizzBuzz.IsBuzz(3));
            Assert.IsFalse(fizzBuzz.IsBuzz(18));
        }

        [TestMethod]
        public void TestFizzBuzz()
        {
            var fizzBuzz = new FizzBuzz();

            Assert.IsTrue(fizzBuzz.IsFizz(15) && fizzBuzz.IsBuzz(15));
            Assert.IsTrue(fizzBuzz.IsFizz(15) && fizzBuzz.IsBuzz(30));
            Assert.IsTrue(fizzBuzz.IsFizz(15) && fizzBuzz.IsBuzz(45));
            
        }
    }
}
