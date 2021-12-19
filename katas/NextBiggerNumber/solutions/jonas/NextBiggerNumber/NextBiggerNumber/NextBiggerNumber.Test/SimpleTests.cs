using NextBiggerNumber.TestAdapter;
using NUnit.Framework;

namespace NextBiggerNumber.Test
{
    public class Tests
    {
        private INextBiggerNumberTestAdapterObject _nextBiggerNumberTestAdapterObject;

        [SetUp]
        public void Setup()
        {
            _nextBiggerNumberTestAdapterObject = NextBiggerNumberTestAdapterFactory.CreateFirstImplementation();
        }

        [Test]
        [TestCase("12", "21")]
        [TestCase("513", "531")]
        [TestCase("2017", "2071")]
        [TestCase("459853", "483559")]
        [TestCase("5983", "8359")]
        [TestCase("9", "-1")]
        [TestCase("111", "-1")]
        [TestCase("531", "-1")]
        public void Test_BiggerNumber(int number, int nextBigger)
        {
            int result = _nextBiggerNumberTestAdapterObject.NextBigger(number);
            Assert.AreEqual(nextBigger, result);
        }
    }
}