using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _5Minds.Services.Tests
{
    [TestClass]
    public class DigitServiceTests
    {
        [TestMethod]
        [DataRow(17L, 71L)]
        [DataRow(2017L, 2071L)]
        [DataRow(513L, 531L)]
        [DataRow(12L, 21L)]
        [DataRow(59884848459853L, 59884848483559L)]
        [DataRow(59213L, 59231L)]
        [DataRow(122L, 212L)]
        [DataRow(44192L, 44219L)]
        public void GetNextBigger_LongNumber_ReturnsFoundNextBigger(long input, long expected)
        {
            long actual = DigitService.GetNextBigger(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1L)]
        [DataRow(111L)]
        [DataRow(531L)]
        [DataRow(9876L)]
        public void GetNextBigger_LongNumber_ReturnsMinusOne(long input)
        {
            long actual = DigitService.GetNextBigger(input);

            Assert.AreEqual(-1L, actual);
        }
    }
}
