using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NextBigger.Tests
{
  [TestClass]
  public class NextBiggerNumberTests
  {
    [DataTestMethod]
    [DataRow(12, 21)]
    [DataRow(513, 531)]
    [DataRow(2017, 2071)]
    [DataRow(459853, 483559)]
    [DataRow(59884848459853, 59884848483559)]
    public void FindNextBiggerNumber_GivenNumberHasResult_ReturnsTrue(long number, long result)
    {
      // Arrange
      var nextBiggerNumber = new NextBiggerNumber();

      // Act
      var actual = nextBiggerNumber.FindNextBiggerNumber(number);

      // Assert
      Assert.AreEqual(result, actual);
    }

    [DataTestMethod]
    [DataRow(9, -1)]
    [DataRow(111, -1)]
    [DataRow(531, -1)]
    public void FindNextBiggerNumber_GivenNumberHasResult_ReturnsFalse(long number, long result)
    {
      // Arrange
      var nextBiggerNumber = new NextBiggerNumber();

      // Act
      var actual = nextBiggerNumber.FindNextBiggerNumber(number);

      // Assert
      Assert.AreEqual(result, actual);
    }
  }
}