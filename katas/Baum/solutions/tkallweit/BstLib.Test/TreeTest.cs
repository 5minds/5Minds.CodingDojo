namespace BstLib.Test
{
    using System.Linq;
    using Xunit;
    public class TreeTest
    {
        [Fact]
        public void TestSortResult()
        {
            // arrange
            int[] keys = new int[] { 30, 15, 60, 7, 20, 40, 79, 11 };

            // act
            var tree = new Tree(keys);
            var result = tree.Sort();

            // assert
            int[] expectedResult = new int[] { 7, 11, 15, 20, 30, 40, 60, 79 };
            Assert.True(expectedResult.Length == result.Count(), "Anzahl der Schlüssel muss gleich sein.");

            int i = 0;
            foreach (var sortedKey in result)
            {
                Assert.True(sortedKey == expectedResult[i], "Sortierung muss gleich sein.");
                i++;
            }
        }

         [Fact]
        public void FindNoKeyTest()
        {
            // arrange
            int[] keys = new int[] { 30, 15, 60, 7, 20, 40, 79, 11 };

            // act
            var tree = new Tree(keys);
            var result = tree.Find(9);

            // assert
            Assert.False(result, "Ein nicht vorhandener Schlüssel wurde gefunden.");
        }
        
        [Fact]
        public void FindKeyTest()
        {
            // arrange
            int[] keys = new int[] { 30, 15, 60, 7, 20, 40, 79, 11 };

            // act
            var tree = new Tree(keys);
            var result = tree.Find(20);

            // assert
            Assert.True(result, "Ein vorhandener Schlüssel wurde nicht gefunden.");
        }
    }
}