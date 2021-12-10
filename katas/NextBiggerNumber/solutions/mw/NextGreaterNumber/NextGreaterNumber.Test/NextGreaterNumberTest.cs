using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NextGreaterNumber.Test
{

    [TestClass]
    public class NextGreaterNumberTest
    {
        private NextGreaterNumber _nextGreaterNumber;
        
        [TestInitialize]
        public void Setup()
        {
           _nextGreaterNumber = new NextGreaterNumber();
        }
        
        [TestMethod]
        public void NextGreaterNumber_GreaterPossible12Success()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(12);
            testResult.Should().Be(21);
        }
        
        [TestMethod]
        public void NextGreaterNumber_GreaterPossible513Success()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(513);
            testResult.Should().Be(531);
        }
        
        [TestMethod]
        public void NextGreaterNumber_GreaterPossible2017Success()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(2017);
            testResult.Should().Be(2071);
        }

        [TestMethod]
        public void NextGreaterNumber_GreaterPossible459853Success()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(459853);
            testResult.Should().Be(483559);
        }
        
        [TestMethod]
        public void NextGreaterNumber_GreaterPossible59884848459853Success()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(59884848459853);
            testResult.Should().Be(59884848483559);
        }
        
        [TestMethod]
        public void NextGreaterNumber_NoGreaterPossibleFailure()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(9);
            testResult.Should().Be(-1);
        }
        
        [TestMethod]
        public void NextGreaterNumber_NoGreaterPossible111Failure()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(111);
            testResult.Should().Be(-1);
        }
        
        [TestMethod]
        public void NextGreaterNumber_NoGreaterPossible531Failure()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(531);
            testResult.Should().Be(-1);
        }

        [TestMethod]
        public void NextGreaterNumber_NoGreaterPossibleNegativeFailure()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(-1);
            testResult.Should().Be(-1);
        }

        [TestMethod]
        public void NextGreaterNumber_MaxLongNoGreaterFailure()
        {
            var testResult = _nextGreaterNumber.FindNextGreaterNumber(long.MaxValue);
            testResult.Should().Be(-1);
        }
    }
}