using NUnit.Framework;
using Palindrom.TestAdapter;

namespace Palindrom.Test
{
    public class PalindromTests
    {
        private IPalindromTestAdapterObject _palindromTestAdapterObject;
        [SetUp]
        public void Setup()
        {
            _palindromTestAdapterObject = PalindromTestAdapterFactory.Create();
        }

        [Test]
        [TestCase("abba", true)]
        [TestCase("Reliefpfeiler", true)]
        [TestCase("Rentner", true)]
        [TestCase("Fumpp", false)]
        [TestCase("Kein Palindrom", false)]
        [TestCase("Dienstmannamtsneid", true)]
        [TestCase("Tarne nie deinen Rat!", true)]
        [TestCase("Eine güldne, gute Tugend: Lüge nie!", true)]
        [TestCase("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!", true)]
        public void Palindrom_Test(string inputString, bool isPalindrom)
        {
            var result = _palindromTestAdapterObject.IsPalindrom(inputString);
            Assert.AreEqual(isPalindrom, result);
        }
    }
}