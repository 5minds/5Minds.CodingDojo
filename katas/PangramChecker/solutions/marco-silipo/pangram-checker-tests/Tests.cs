using System;
using System.Linq;
using Common;
using NUnit.Framework;


namespace PangramChecker.Tests
{

    public class Tests
    {
        private const string OnlyAsLetter = "aaaaaaaaaaaaAAAAAAAAAAAAAaaaaaaaaaaaaaaAAAAAAAAAAAA";
        private const string AbcCorrect = "abcdefghijklmnopqrstuvwxyz";
        private const string QuickBrownFoxCorrect = "The quick brown fox jumps over the lazy dog";
        private PangramValidator _validator = null!;
        private Random _random = null!;
        
        [SetUp]
        public void Setup()
        {
            _validator = new PangramValidator();
            _random = new Random();
        }

        [Test]
        public void QuickBrownFoxIsPangram()
        {
            Assert.True(_validator.IsPangram(QuickBrownFoxCorrect));
        }

        [Test]
        public void AbcIsPangram()
        {
            Assert.True(_validator.IsPangram(AbcCorrect));
        }

        [Test]
        public void AbcRandomCasingIsPangram()
        {
            var randomizedAbc = AbcCorrect.RandomizeCasing();
            Assert.True(_validator.IsPangram(randomizedAbc));
        }

        [Test]
        public void StringOfOnlyAIsNoPangram()
        {
            Assert.False(_validator.IsPangram(OnlyAsLetter));
        }

        [Test]
        public void QuickBrownFoxIsImperfectPangram()
        {
            Assert.AreEqual(EPangramType.Imperfect, _validator.GetPangramType(QuickBrownFoxCorrect));
        }

        [Test]
        public void AbcIsPerfectPangram()
        {
            Assert.AreEqual(EPangramType.Perfect, _validator.GetPangramType(AbcCorrect));
        }

        [Test]
        public void AbcRandomCasingIsPerfectPangram()
        {
            var randomizedAbc = AbcCorrect.RandomizeCasing();
            Assert.AreEqual(EPangramType.Perfect, _validator.GetPangramType(randomizedAbc));
        }

        [Test]
        public void AbcShuffledIsPerfectPangram()
        {
            var shuffledAbc = AbcCorrect.ShuffleChars();
            Assert.AreEqual(EPangramType.Perfect, _validator.GetPangramType(shuffledAbc));
        }

        [Test]
        public void StringOfOnlyAIsInvalidPangram()
        {
            Assert.AreEqual(EPangramType.Invalid, _validator.GetPangramType(OnlyAsLetter));
        }
    }
}