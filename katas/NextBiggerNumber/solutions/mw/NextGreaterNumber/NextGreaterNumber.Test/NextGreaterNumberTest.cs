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
    }
}