namespace NextBiggerNumber.Tests
{
    using Xunit;
    using NextBiggerNumber;

    public class UnitTestNextBiggerNumber
    {


        [Theory]
        [InlineData(12L, 21L)]
        [InlineData(513L, 531L)]
        [InlineData(2017L, 2071L)]
        [InlineData(459853L, 483559L)]
        [InlineData(59884848459853L, 59884848483559L)]
        [InlineData(9L, -1L)]
        [InlineData(11L, -1L)]
        [InlineData(531L, -1L)]
        public void ShouldGetNextBiggerNumber(long nNumber, long nExpected)
        {
            Assert.Equal(Numbers.GetNextBiggerNumber(nNumber), nExpected);
        }

    }
}
