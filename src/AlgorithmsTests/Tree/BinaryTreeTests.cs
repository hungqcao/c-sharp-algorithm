using Algorithms.Tree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.Tests
{
    [TestFixture()]
    public class BinaryTreeTests
    {
        [Test()]
        public void ConstructMaximumBinaryTreeV2Test()
        {
            BinaryTreeProblems.ConstructMaximumBinaryTreeV2(new int[] { 3, 2, 1, 6, 0, 5 });
        }

        [Test()]
        public void PruneTreeTest()
        {
            {
                var node1 = new TreeNode(1);
                var node2 = new TreeNode(0);
                var node3 = new TreeNode(1);
                var node4 = new TreeNode(0);
                var node5 = new TreeNode(0);
                var node6 = new TreeNode(0);
                var node7 = new TreeNode(1);
                node1.left = node2;
                node1.right = node3;
                node2.left = node4;
                node2.right = node5;
                node3.left = node6;
                node3.right = node7;


                BinaryTreeProblems.PruneTree(node1);
            }
            {
                var node1 = new TreeNode(1);
                var node2 = new TreeNode(0);
                var node3 = new TreeNode(0);
                var node4 = new TreeNode(1);
                node1.right = node2;
                node2.left = node3;
                node2.right = node4;

                BinaryTreeProblems.PruneTree(node1);
            }
        }
    }
}

namespace UnitTestProject.Tree
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void Test_BinaryTreePaths()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.right = node5;

            var result = Algorithms.Tree.BinaryTreeProblems.BinaryTreePaths(node1);
            Assert.AreEqual(result.Count, 2);
        }

        [Test]
        public void Test_IsSymmetric_Iterative()
        {
            var node1 = new TreeNode(1);
            var node2_1 = new TreeNode(2);
            var node2_2 = new TreeNode(2);
            var node3_1 = new TreeNode(3);
            var node3_2 = new TreeNode(3);
            var node4_1 = new TreeNode(4);
            var node4_2 = new TreeNode(4);

            node1.left = node2_1;
            node1.right = node2_2;
            node2_1.left = node3_1;
            node2_1.right = node4_1;
            node2_2.left = node4_2;
            node2_2.right = node3_2;       

            var result = Algorithms.Tree.BinaryTreeProblems.IsSymmetric_Iterative(node1);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Test_IsSymmetric_Iterative_ReturnFalse()
        {
            //[2,3,3,4,5,5]
            var node2 = new TreeNode(2);
            var node3_1 = new TreeNode(3);
            var node3_2 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5_1 = new TreeNode(5);
            var node5_2 = new TreeNode(5);

            node2.left = node3_1;
            node2.right = node3_2;
            node3_1.left = node4;
            node3_1.right = node5_1;
            node3_2.left = node5_2;

            var result = Algorithms.Tree.BinaryTreeProblems.IsSymmetric_Iterative(node2);
            Assert.AreEqual(result, false);
        }

        [Test]
        public void Test_PathSum2()
        {
            var node1 = new TreeNode(5);
            var node2 = new TreeNode(4);
            var node3 = new TreeNode(8);
            var node4 = new TreeNode(11);
            var node5 = new TreeNode(13);
            var node6 = new TreeNode(4);
            var node7 = new TreeNode(7);
            var node8 = new TreeNode(2);
            var node9 = new TreeNode(5);
            var node10 = new TreeNode(1);
            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node3.left = node5;
            node3.right = node6;
            node4.left = node7;
            node4.right = node8;
            node6.left = node9;
            node6.right = node10;

            var result = Algorithms.Tree.BinaryTreeProblems.PathSum(node1, 22);
            Assert.AreEqual(result.Count, 2);
        }

        [Test]
        public void Test_LevelOrder()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.right = node5;

            var result = Algorithms.Tree.BinaryTreeProblems.LevelOrder(node1);
            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void Test_ZigzagLevelOrder()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.right = node5;

            var result = Algorithms.Tree.BinaryTreeProblems.ZigzagLevelOrder(node1);
            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void Test_ConstructMaximumBinaryTree()
        {
            var node = Algorithms.Tree.BinaryTreeProblems.ConstructMaximumBinaryTree(new int[] { 3, 2, 1, 6, 0, 5 });

            node = Algorithms.Tree.BinaryTreeProblems.ConstructMaximumBinaryTreeV2(new int[] { 3, 2, 1, 6, 0, 5 });
        }

        [Test]
        public void Test_LargestValues()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.right = node5;

            var result = Algorithms.Tree.BinaryTreeProblems.LargestValues(node1);
            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void Test_FindFrequentTreeSum()
        {

            var node1 = new TreeNode(2);
            var node2 = new TreeNode(5);
            var node3 = new TreeNode(-3);
            node2.left = node1;
            node2.right = node3;

            Assert.AreEqual(1, Algorithms.Tree.BinaryTreeProblems.FindFrequentTreeSum(node2));
        }

        [Test]
        public void Test_KthSmallest()
        {
            var node1 = new TreeNode(2);
            node1.left = new TreeNode(1);

            Assert.AreEqual(1, Algorithms.Tree.BinarySearchTree.BSTProblems.KthSmallest(node1, 1));
        }
    }
}
