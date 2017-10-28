using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Arrays
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod_FindLengthOfLCIS()
        {
            Assert.AreEqual(3, Algorithms.ArrayProb.Arrays.FindLengthOfLCIS(new int[] { 1, 3, 5, 4, 7 }));
            Assert.AreEqual(1, Algorithms.ArrayProb.Arrays.FindLengthOfLCIS(new int[] { 2, 2, 2, 2, 2 }));
            Assert.AreEqual(5, Algorithms.ArrayProb.Arrays.FindLengthOfLCIS(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(1, Algorithms.ArrayProb.Arrays.FindLengthOfLCIS(new int[] { 3, 2, 1 }));
            Assert.AreEqual(6, Algorithms.ArrayProb.Arrays.FindLengthOfLCIS(new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 5, 6 }));
        }

        [TestMethod]
        public void Test_Generate_PascalTriangle()
        {
            var ret = Algorithms.ArrayProb.Arrays.Generate(5);

            Assert.AreEqual(5, ret.Count);
        }

        [TestMethod]
        public void Test_FindMaxAverage()
        {
            var input = new int[] { 1, 12, -5, -6, 50, 3 };
            var output = Algorithms.ArrayProb.Arrays.FindMaxAverage(input, 4);
            Assert.Equals(12.75, output);
        }

        [TestMethod]
        public void Test_GetRow()
        {
            var input = Algorithms.ArrayProb.Arrays.GetRow(0);
            CollectionAssert.AreEqual(new int[] { 1 }, input.ToArray());
            input = Algorithms.ArrayProb.Arrays.GetRow(1);
            CollectionAssert.AreEqual(new int[] { 1, 1 }, input.ToArray());
            input = Algorithms.ArrayProb.Arrays.GetRow(2);
            CollectionAssert.AreEqual(new int[] { 1, 2, 1 }, input.ToArray());
            input = Algorithms.ArrayProb.Arrays.GetRow(3);
            CollectionAssert.AreEqual(new int[] { 1, 3, 3, 1 }, input.ToArray());
            input = Algorithms.ArrayProb.Arrays.GetRow(4);
            CollectionAssert.AreEqual(new int[] { 1, 4, 6, 4, 1 }, input.ToArray());
        }

        [TestMethod]
        public void Test_TwoSum()
        {
            var input = Algorithms.ArrayProb.Arrays.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            CollectionAssert.AreEqual(new int[] { 0, 1 }, input.ToArray());
        }

        [TestMethod]
        public void Test_ThreeSum()
        {
            var output = Algorithms.ArrayProb.Arrays.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            Assert.AreEqual(output.Count, 2);
        }
    }
}
