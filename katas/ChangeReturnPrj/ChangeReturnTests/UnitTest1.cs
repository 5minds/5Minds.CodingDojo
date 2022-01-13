using System;
using Xunit;
using ClassesChangeReturn;

namespace ChangeReturnTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CChangeReturn oChangeReturn = new CChangeReturn();
            decimal[] arrValidChanges = new decimal[3]{ 50, 20, 10 };
            
            Assert.Equal(arrValidChanges, oChangeReturn.fCalcChangeReturn(420, 500).ToArray());
            // Assert.Equal(4,4);
        }
    }
}
