using System;
using Xunit;

namespace PangramChecker.Tests
{
    public class PangramCheck
    {
        [Theory]
        [InlineData("a", "a does not contains all alphabet letters at least once.")]
        [InlineData("", " does not contains all alphabet letters at least once.")]
        [InlineData("AbCdEfGHIJKLmnopqrstuvwxyZ! .", "AbCdEfGHIJKLmnopqrstuvwxyZ! . contains all alphabet letters exactly once.")]
        [InlineData("aAaAAbCdEfGHIJKLmnopqrstuvwxyZ! .", "aAaAAbCdEfGHIJKLmnopqrstuvwxyZ! . contains all alphabet letters more than once.")]
        [InlineData("The quick brown fox jumps over the lazy dog", "The quick brown fox jumps over the lazy dog contains all alphabet letters more than once.")]
        public void PangramTests(string input, string result)
        {

            Assert.Equal(result, PangramStringChecker.CheckPangram(input));
        }
    }
}
