using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Algorithms.Tree;

namespace UnitTestProject.Tree
{
    /// <summary>
    /// Summary description for BST
    /// </summary>
    [TestFixture]
    public class BST
    {
        public BST()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Test]
        public void Test_FindMode()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node2_1 = new TreeNode(2);
            node1.right = node2;
            node2.left = node2_1;

            var output = Algorithms.Tree.BinarySearchTree.BSTProblems.FindMode(node1);
            var actual = new int[] { 2 };
            Assert.AreEqual(actual[0], output[0]);

            node1 = new TreeNode(1);
            node2 = new TreeNode(2);
            node1.right = node2;

            output = Algorithms.Tree.BinarySearchTree.BSTProblems.FindMode(node1);
            Assert.AreEqual(new int[] { 2, 1 }, output);
        }

        [Test]
        public void Test_Serialize_Deserialize()
        {
            var node1 = new TreeNode(5);
            node1.left = new TreeNode(3);
            node1.left.left = new TreeNode(2);
            node1.right = new TreeNode(6);
            node1.right.right = new TreeNode(7);

            var output = Algorithms.Tree.BinarySearchTree.BSTProblems.serialize(node1);
            var deserialize = Algorithms.Tree.BinarySearchTree.BSTProblems.deserialize(output);
        }
    }
}
