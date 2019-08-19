using NUnit.Framework;
using Algorithms.Tree.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree.Tests
{
    [TestFixture()]
    public class BST
    {
        [Test()]
        public void KthLargestTest()
        {
            var root = new TreeNode(8);
            root.left = new TreeNode(3);
            root.right = new TreeNode(10);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(6);
            root.left.right.left = new TreeNode(4);
            root.left.right.right = new TreeNode(7);
            root.right.right = new TreeNode(14);
            root.right.right.left = new TreeNode(13);

            var val = BSTProblems.KthLargest(root, 2);
        }
    }
}