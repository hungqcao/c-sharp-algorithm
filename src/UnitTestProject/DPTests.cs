using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DP;

namespace UnitTestProject
{
    [TestClass]
    public class DPTests
    {
        [TestMethod]
        public void Test_NumTrees()
        {
            Assert.AreEqual(5, DynamicProgramming.NumTrees(3));
        }

        [TestMethod]
        public void Test_CoinChange()
        {
            Assert.AreEqual(3, DynamicProgramming.CoinChange(new int[] { 2, 3, 5 }, 11));
            Assert.AreEqual(3, DynamicProgramming.CoinChange(new int[] { 2 }, 3));
            Assert.AreEqual(3, DynamicProgramming.CoinChange(new int[] { 1 }, 0));
        }

        [TestMethod]
        public void Test_CanPartition()
        {
            Assert.AreEqual(true, DynamicProgramming.CanPartition(new int[] { 1, 5, 11, 5 }));
        }

        [TestMethod]
        public void Test_SubSetSum()
        {
            var ret = DynamicProgramming.subsetSum(new int[] { 1, 5, 5, 11 }, 11);
            ret = DynamicProgramming.subsetSum(new int[] { 4, 3, 2, 3, 5, 2, 1 }, 5);
        }

        [TestMethod]
        public void Test_LongestPalindromeSubseq()
        {
            Assert.AreEqual(4, DynamicProgramming.LongestPalindromeSubseq("bbbab"));
        }
    }
}
