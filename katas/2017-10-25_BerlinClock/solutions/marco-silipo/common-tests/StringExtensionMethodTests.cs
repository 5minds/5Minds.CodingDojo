using NUnit.Framework;

namespace Common.Tests
{
    public class StringExtensionMethodTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RandomizeCasingTest()
        {
            // ReSharper disable once StringLiteralTypo
            var str = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Assert.AreNotEqual(str, str.RandomizeCasing());
        }

        [Test]
        public void RandomizeCasingWithUmlautsTest()
        {
            // ReSharper disable once StringLiteralTypo
            var str = "äüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäüöäü";
            Assert.AreNotEqual(str, str.RandomizeCasing());
        }

        [Test]
        public void ShuffleCharactersNotEqualTest()
        {
            // ReSharper disable once StringLiteralTypo
            var str = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopq";
            Assert.AreNotEqual(str, str.ShuffleChars());
        }

        [Test]
        public void ShuffleCharactersSequenceNotContainedTest()
        {
            // ReSharper disable once StringLiteralTypo
            var str = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopq";
            // ReSharper disable once StringLiteralTypo
            var abc = "abcdefghijklmnopqrstuvwxyz";
            Assert.False(str.ShuffleChars().Contains(abc));
        }

        [Test]
        public void ShuffleCharactersSequenceReversedNotContainedTest()
        {
            // ReSharper disable once StringLiteralTypo
            var str = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopq";
            // ReSharper disable once StringLiteralTypo
            var abc = "zyxwvutsrqponmlkjihgfedcba";
            Assert.False(str.ShuffleChars().Contains(abc));
        }
    }
}