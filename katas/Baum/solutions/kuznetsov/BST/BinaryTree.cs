using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public BinaryTreeNode LeftChild { get; set; }   
        public BinaryTreeNode RightChild { get; set; }
    }
}