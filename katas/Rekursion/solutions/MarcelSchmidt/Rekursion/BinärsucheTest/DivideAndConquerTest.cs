using Binärsuche;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinärsucheTest
{
    [TestClass]
    public class DivideAndConquerTest
    {
        [TestMethod]
        public void Search_LetterA_ReturnsTrue()
        {
            if (!DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), 'A', false))
            {
                Assert.Fail("Character 'A' could not be found!");
            }
        }

        [TestMethod]
        public void Search_LetterZ_ReturnsTrue()
        {
            if (!DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), 'Z', false))
            {
                Assert.Fail("Character 'Z' could not be found!");
            }
        }

        [TestMethod]
        public void Search_LetterN_ReturnsTrue()
        {
            if (!DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), 'N', false))
            {
                Assert.Fail("Character 'N' could not be found!");
            }
        }

        [TestMethod]
        public void Search_LetterO_ReturnsTrue()
        {
            if (!DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), 'O', false))
            {
                Assert.Fail("Character 'O' could not be found!");
            }
        }

        [TestMethod]
        public void Search_LetterL_ReturnsTrue()
        {
            if (!DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), 'L', false))
            {
                Assert.Fail("Character 'L' could not be found!");
            }
        }

        [TestMethod]
        public void Search_LetterLowerA_ReturnsFalse()
        {
            if (DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), 'a', false))
            {
                Assert.Fail("Character 'a' was found!");
            }
        }

        [TestMethod]
        public void Search_LetterLowerN_ReturnsFalse()
        {
            if (DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), 'n', false))
            {
                Assert.Fail("Character 'n' was found!");
            }
        }


        [TestMethod]
        public void Search_Numeric1_ReturnsFalse()
        {
            if (DivideAndConquer.Search(DivideAndConquerHelper.GetSearchAreaAlphabet(), '1', false))
            {
                Assert.Fail("Character '1' was found!");
            }
        }
    }
}
