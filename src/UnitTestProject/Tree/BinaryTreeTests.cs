using Algorithms.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tree
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TestMethod_BinaryTreePaths()
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

        [TestMethod]
        public void TestMethod_IsSymmetric_Iterative()
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

        [TestMethod]
        public void TestMethod_IsSymmetric_Iterative_ReturnFalse()
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

        [TestMethod]
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
    }
}
