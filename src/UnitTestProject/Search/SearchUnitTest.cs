using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Search;

namespace UnitTestProject.Search
{
    [TestClass]
    public class SearchUnitTest
    {
        [TestMethod]
        public void Test_kthSmallest()
        {
            int[,] arr = new int[,]
            {
                { 1, 5 , 9},
                {10, 11, 13 },
                {12, 13, 15 }
            };
            Assert.AreEqual(13, BinarySearch.kthSmallest(arr, 8));
        }

        [TestMethod]
        public void Test_Search()
        {
            Assert.AreEqual(0, BinarySearch.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4));
            Assert.AreEqual(1, BinarySearch.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 5));
            Assert.AreEqual(2, BinarySearch.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6));
            Assert.AreEqual(3, BinarySearch.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 7));
            Assert.AreEqual(4, BinarySearch.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
            Assert.AreEqual(5, BinarySearch.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1));
            Assert.AreEqual(6, BinarySearch.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 2));
            Assert.AreEqual(-1, BinarySearch.Search(new int[] { 1 }, 0));            
        }

        [TestMethod]
        public void Test_SearchAllDupp()
        {
            Assert.AreEqual(true, BinarySearch.SearchAllowDupp(new int[] { 3, 1 }, 1));
        }

        [TestMethod]
        public void Test_IsSubsequence()
        {
            Assert.AreEqual(true, BinarySearch.IsSubsequence("abc", "ahbgdc"));
            Assert.AreEqual(true, BinarySearch.IsSubsequence("aec", "abcde"));
        }
    }
}
