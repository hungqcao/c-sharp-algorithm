using System;
using NUnit.Framework;
using Algorithms.Backtracking;

namespace UnitTestProject.BackTrack
{
    [TestFixture]
    public class BacktrackingTest
    {
        [Test]
        public void Test_CombinationSum3()
        {
            var ret = BackTrackingProblems.CombinationSum3(3, 7);
            Assert.AreEqual(1, ret.Count);
            
            Assert.AreEqual(3, BackTrackingProblems.CombinationSum3(3, 9));
        }


        [Test]
        public void Test_Permute()
        {
            Assert.AreEqual(3, BackTrackingProblems.Permute(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void Test_PermuteUnique()
        {
            Assert.AreEqual(3, BackTrackingProblems.PermuteUnique(new int[] { 1, 1, 2 }));
        }

        [Test]
        public void Test_Combine()
        {
            Assert.AreEqual(6, BackTrackingProblems.Combine(4, 2));
        }

        [Test]
        public void Test_CombinationSum()
        {
            var ret = BackTrackingProblems.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        }

        [Test]
        public void Test_CombinationSum2()
        {
            var ret = BackTrackingProblems.CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
        }
        
    }
}
