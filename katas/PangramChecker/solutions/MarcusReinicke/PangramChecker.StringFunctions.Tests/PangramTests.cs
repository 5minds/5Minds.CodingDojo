using System.Linq;
using System.Reflection;
using Xunit;

namespace PangramChecker.StringFunctions.Tests
{
    /// <summary>
    /// Testclass for Pangram Class.
    /// </summary>
    public class PangramTests
    {
        /// <summary>
        /// Method to test the private methode CheckStringSequenceForPangram.
        /// </summary>
        /// <param name="stringSequence">A pangram sequence.</param>
        /// <param name="expectedValue">The expected Value.</param>
        [Theory]
        [InlineData("abcdefghijklmnopqrstuvwxyz", new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
        [InlineData("The quick brown fox jumps over the lazy dog", new int[] { 1, 1, 1, 1, 3, 1, 1, 2, 1, 1, 1, 1, 1, 1, 4, 1, 1, 2, 1, 2, 2, 1, 1, 1, 1, 1 })]
        [InlineData("abcdefgh", new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        public void CheckStringSequenceForPangramTest(string stringSequence, int[] expectedValue)
        {
            // Arrange
            Pangram pangramTestObj = new Pangram(stringSequence);
            MethodInfo methodInfo = typeof(Pangram).GetMethod("CheckStringSequenceForPangram", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(pangramTestObj, null);

            // Act
            FieldInfo[] myFieldInfo = typeof(Pangram).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var resultArray = myFieldInfo.Where(x => x.Name == "_resultArray").FirstOrDefault();
            var resultArrayValues = resultArray.GetValue(pangramTestObj);

            // Assert
            Assert.Equal(resultArrayValues, expectedValue);
        }

        /// <summary>
        /// Method to test the private methode ParseResultArray.
        /// </summary>
        /// <param name="array">The arry fill with examples.</param>
        /// <param name="expectedText">The expected Value.</param>
        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "contains all alphabet letters exactly once")]
        [InlineData(new int[] { 1, 1, 1, 6, 1, 1, 1, 4, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1 }, "contains all alphabet letters more than once")]
        [InlineData(new int[] { 0, 0, 0, 0, 1, 1, 1, 4, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1 }, "does not contain all alphabet letters at least once")]
        public void ParseResultArrayTest(int[] array, string expectedText)
        {
            // Arrange
            Pangram pangramTestObj = new Pangram(string.Empty);
            FieldInfo[] myFieldInfo = typeof(Pangram).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var resultArray = myFieldInfo.Where(x => x.Name == "_resultArray").FirstOrDefault();
            resultArray.SetValue(pangramTestObj, array);
            MethodInfo methodInfo = typeof(Pangram).GetMethod("ParseResultArray", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            methodInfo.Invoke(pangramTestObj, null);

            // Assert
            Assert.Equal(pangramTestObj.Result, expectedText);
        }
    }
}