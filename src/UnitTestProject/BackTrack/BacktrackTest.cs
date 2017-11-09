using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Backtracking;

namespace UnitTestProject.BackTrack
{
    [TestClass]
    public class BacktrackingTest
    {
        [TestMethod]
        public void Test_CombinationSum3()
        {
            var ret = BackTrackingProblems.CombinationSum3(3, 7);
            Assert.AreEqual(1, ret.Count);
            
            Assert.AreEqual(3, BackTrackingProblems.CombinationSum3(3, 9));
        }


        [TestMethod]
        public void Test_Permute()
        {
            Assert.AreEqual(3, BackTrackingProblems.Permute(new int[] { 1, 2, 3 }));
        }
    }
}
