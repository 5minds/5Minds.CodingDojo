using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class BinarySearchTree
    {
        private readonly BinaryTreeNode _tree;
        public BinarySearchTree(BinaryTreeNode root)
        {
            _tree = root;
        }

        public static BinarySearchTree? CreateTestBst()
        {
            return new BinarySearchTree(new List<int> { 30, 15, 60, 7, 20, 40, 79, 11 });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initList">an array of node values, the first element is the root node value, 
        /// followed by values of the tree node levels from left to right</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BinarySearchTree(List<int> initList)
        {
            if (initList == null || initList.Count == 0)
                throw new ArgumentNullException(nameof(initList));
            _tree = new BinaryTreeNode(initList[0]);
            for (int i = 1; i < initList.Count; i++)
                AddChild(_tree, initList[i]);
        }

        public BinaryTreeNode? findNode(int value, BinaryTreeNode? node = null)
        {
            if(_tree == null)
                return null;
            if (node == null)
                return findNode(value, _tree);
            
            if(node.Value == value) // found!
                return node;
            if (node.Value > value)
                return node.LeftChild == null ? null // not found!
                    :
                    findNode(value, node.LeftChild);
            if (node.RightChild == null)
                return null; // not found!
            return findNode(value, node.RightChild);
        }

        public string printTree()
        {
            if(_tree == null)
                return "the tree is empty!";
            string result = "";
            printNode(_tree, ref result);
            return result;
        }

        private void printNode(BinaryTreeNode node, ref string result)
        {
            if(node == null)
                throw new ArgumentNullException(nameof(node));
            if(node.LeftChild != null)
                printNode(node.LeftChild, ref result);
            //add current value
            if(string.IsNullOrEmpty(result))
                result = node.Value.ToString();
            else 
                result += ", " + node.Value.ToString();
            // add the right sub-tree
            if(node.RightChild != null)
                printNode(node.RightChild, ref result);
        }

        private void AddChild(BinaryTreeNode node, int value)
        {
            if(node == null)
                throw new ArgumentNullException(nameof(node));
            if(value == node.Value)
                return;
            if(value > node.Value)
            {
                if(node.RightChild == null)
                {
                    node.RightChild = new BinaryTreeNode(value);
                    return;
                }
                AddChild(node.RightChild, value);
                return;
            }
            if(node.LeftChild == null)
            {
                node.LeftChild = new BinaryTreeNode(value);
                return;
            }
            AddChild(node.LeftChild, value);
        }
    }
}
