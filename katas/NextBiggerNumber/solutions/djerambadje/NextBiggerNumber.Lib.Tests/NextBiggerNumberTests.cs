using NUnit.Framework;

namespace NextBiggerNumber.Lib.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NextBiggerWhenNumberLengthIs_One()
        {
            NextBiggerNumberGenerator generator = new NextBiggerNumberGenerator();
            long number = 9;
            Assert.AreEqual(-1, generator.NextBigger(number));
        }

        [Test]
        public void NextBiggerWhenNumberDigitsAreDescendingSorted()
        {
            NextBiggerNumberGenerator generator = new NextBiggerNumberGenerator();
            long number = 531;
            Assert.AreEqual(-1, generator.NextBigger(number));
        }

        [Test]
        public void NextBiggerWhenNumberDigitsAreAscendingSorted()
        {
            NextBiggerNumberGenerator generator = new NextBiggerNumberGenerator();
            long number = 12345;
            Assert.AreEqual(12354, generator.NextBigger(number));
        }


        [Test]
        public void NextBiggerWhenNumberDigitsAreSame()
        {
            NextBiggerNumberGenerator generator = new NextBiggerNumberGenerator();
            long number = 111;
            Assert.AreEqual(-1, generator.NextBigger(number));
        }

        [Test]
        public void NextBiggerWhenNumberIs_513()
        {
            NextBiggerNumberGenerator generator = new NextBiggerNumberGenerator();
            long number = 513;
            Assert.AreEqual(531, generator.NextBigger(number));
        }

        [Test]
        public void NextBiggerWhenNumberIs_2017()
        {
            NextBiggerNumberGenerator generator = new NextBiggerNumberGenerator();
            long number = 2017;
            Assert.AreEqual(2071, generator.NextBigger(number));
        }


        [Test]
        public void NextBigger()
        {
            NextBiggerNumberGenerator generator = new NextBiggerNumberGenerator();
            long number = 59884848459853;
            Assert.AreEqual(59884848483559, generator.NextBigger(number));
        }
    }
}