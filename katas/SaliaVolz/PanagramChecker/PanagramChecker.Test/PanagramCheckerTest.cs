using Microsoft.VisualStudio.TestTools.UnitTesting;
using PanagramChecker;

namespace PanagramChecker.Test
{
    [TestClass]
    public class PanagramCheckerTest
    {
        [TestMethod]
        [DataRow("Hello")]
        [DataRow("The quick brown fox jumps over the dog")]
        [DataRow("")]
        [DataRow("42")]
        [DataRow("%$§&-")]
        public void IsPangram_ReturnFalse(string value)
        {
            Assert.IsFalse(PanagramChecker.IsPangram(value));
        }

        [TestMethod]
        [DataRow("The quick brown fox jumps over the lazy dog")]
        [DataRow("abcdefghijklmnopqrstuvwxyz")]
        [DataRow("The quick brown fox jumps over the lazy dog The quick brown fox jumps over the lazy dog")]
        [DataRow("abcdefghijklmnopqrstuvwxyz42")]
        [DataRow("abcdefghijklmnopqrstuvwxyz%$§&-")]
        public void IsPangram_ReturnTrue(string value)
        {
            Assert.IsTrue(PanagramChecker.IsPangram(value));
        }

        [TestMethod]
        [DataRow("Hello")]
        [DataRow("The quick brown fox jumps over the dog")]
        [DataRow("")]
        [DataRow("42")]
        [DataRow("%$§&-")]
        public void IsDuplicate_ReturnFalse(string value)
        {
            Assert.IsFalse(PanagramChecker.IsDuplicate(value));
        }

        [TestMethod]
        [DataRow("The quick brown fox jumps over the lazy lazy dog")]
        [DataRow("aabcdefghijklmnopqrstuvwxyz")]
        [DataRow("The quick brown fox jumps over the lazy dog The quick brown fox jumps over the lazy dog")]
        [DataRow("4242")]
        [DataRow("-aabcdefghijklmnopqrstuvwxyz-")]
        public void IsDuplicate_ReturnTrue(string value)
        {
            Assert.IsTrue(PanagramChecker.IsDuplicate(value));
        }
    }
}
