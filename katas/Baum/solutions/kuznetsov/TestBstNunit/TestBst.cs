using NUnit.Framework;

namespace TestBstNunit
{
    public class Tests
    {
        private BST.BinarySearchTree? _tree;
        [SetUp]
        public void Setup()
        {
            _tree = BST.BinarySearchTree.CreateTestBst();
        }

        [Test]
        public void TestFind()
        {
            var node = _tree.findNode(60);
            Assert.IsNotNull(node);
        }
        [Test]
        public void TestPrint()
        {
            Assert.AreEqual(_tree.printTree(), "7, 11, 15, 20, 30, 40, 60, 79");
        }
    }
}