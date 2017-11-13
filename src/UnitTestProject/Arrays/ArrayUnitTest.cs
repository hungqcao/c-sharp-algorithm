using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Arrays
{
    [TestClass]
    public class ArrayUnitTest
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

        [TestMethod]
        public void Test_ContainsNearbyAlmostDuplicate()
        {
            var output = Algorithms.ArrayProb.Arrays.ContainsNearbyAlmostDuplicate(new int[] { -2147483648, -2147483647 }, 3, 3);
            Assert.AreEqual(true, output);
            output = Algorithms.ArrayProb.Arrays.ContainsNearbyAlmostDuplicate(new int[] { -3, 3 }, 2, 4);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void Test_TrappingWater()
        {
            var output = Algorithms.ArrayProb.Arrays.Trap1(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        }

        [TestMethod]
        public void Test_FindUnsortedSubarray()
        {
            var output = Algorithms.ArrayProb.Arrays.FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 9, 15 });
            Assert.AreEqual(5, output);

            output = Algorithms.ArrayProb.Arrays.FindUnsortedSubarray(new int[] { 1, 2, 3, 4 });
            Assert.AreEqual(5, output);
        }

        [TestMethod]
        public void Test_SearchMatrix()
        {
            int[,] arr = new int[,]
            {
                { 1, 3, 5, 7 },
                { 10, 11, 16, 20},
                { 23, 30, 34, 50}
            };

            var output = Algorithms.ArrayProb.Arrays.SearchMatrix(arr, 11);
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix(arr, 11));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix(arr, 3));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix(arr, 50));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix(arr, 23));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix(arr, 1));
            arr = new int[,] { { 1 } };

            output = Algorithms.ArrayProb.Arrays.SearchMatrix(arr, 2);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void Test_SearchMatrix2()
        {
            int[,] arr = new int[,]
            {
                { 1,   4,  7, 11, 15 },
                { 2,   5,  8, 12, 19},
                { 3,   6,  9, 16, 22},
                { 10, 13, 14, 17, 24 },
                { 18, 21, 23, 26, 30 }
            };
            
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix2(arr, 11));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix2(arr, 30));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix2(arr, 6));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix2(arr, 10));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.SearchMatrix2(arr, 22));

            arr = new int[,] { { -5 } };

            Assert.AreEqual(false, Algorithms.ArrayProb.Arrays.SearchMatrix2(arr, -10));
        }

        [TestMethod]
        public void Test_CheckPossibility()
        {
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.CheckPossibility(new int[] { 3, 1, 2, 3, 4 }));
            Assert.AreEqual(true, Algorithms.ArrayProb.Arrays.CheckPossibility(new int[] { 1, 2, 3, 4 }));
            Assert.AreEqual(false, Algorithms.ArrayProb.Arrays.CheckPossibility(new int[] { 4, 2, 1 }));
            Assert.AreEqual(false, Algorithms.ArrayProb.Arrays.CheckPossibility(new int[] { 5, 4, 3, 3, 4 }));
            Assert.AreEqual(false, Algorithms.ArrayProb.Arrays.CheckPossibility(new int[] { 3, 4, 2, 3 }));
        }

        [TestMethod]
        public void Test_FindLength()
        {
            var A = new int[] { 1, 2, 3, 2, 1 };
            var B = new int[] { 3, 2, 1, 4, 7 };

            Assert.AreEqual(3, Algorithms.ArrayProb.Arrays.FindLength(A, B));
        }

        [TestMethod]
        public void Test_FindDupplicates()
        {
            var A = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            var output = Algorithms.ArrayProb.Arrays.FindDupplicates(A);

            Assert.AreEqual(2, output.Count);
        }

        [TestMethod]
        public void Test_CountArrangement()
        {
            Assert.AreEqual(2, Algorithms.ArrayProb.Arrays.CountArrangement(2));
        }

        [TestMethod]
        public void Test_SingleNumber()
        {
            Assert.AreEqual(2, Algorithms.ArrayProb.Arrays.SingleNumber(new int[] { 1, 2, 1, 3, 2, 5 }).Length);
        }

        [TestMethod]
        public void Test_LengthOfLIS()
        {
            Assert.AreEqual(4, Algorithms.ArrayProb.Arrays.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
            Assert.AreEqual(6, Algorithms.ArrayProb.Arrays.LengthOfLIS(new int[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 }));
            Assert.AreEqual(4, Algorithms.ArrayProb.Arrays.LengthOfLIS_BinarySearch(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
            Assert.AreEqual(6, Algorithms.ArrayProb.Arrays.LengthOfLIS_BinarySearch(new int[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 }));
        }

        [TestMethod]
        public void Test_IncreasingTriplet()
        {
            Assert.AreEqual(false, Algorithms.ArrayProb.Arrays.IncreasingTriplet(new int[] { 2, 4, -2, -3 }));
        }

        [TestMethod]
        public void Test_FindNumberOfLIS()
        {
            Assert.AreEqual(2, Algorithms.ArrayProb.Arrays.FindNumberOfLIS(new int[] { 1, 3, 5, 4, 7 }));
            Assert.AreEqual(5, Algorithms.ArrayProb.Arrays.FindNumberOfLIS(new int[] { 2, 2, 2, 2, 2 }));
            Assert.AreEqual(3, Algorithms.ArrayProb.Arrays.FindNumberOfLIS(new int[] { 1, 2, 4, 3, 5, 4, 7, 2 }));
        }

        [TestMethod]
        public void Test_NextGreaterElements()
        {
            CollectionAssert.AreEquivalent(new int[] { 120, 11, 120, 120, 123, 123, -1, 100, 100, 100 }, Algorithms.ArrayProb.Arrays.NextGreaterElements(new int[] { 100, 1, 11, 1, 120, 111, 123, 1, -1, -100 }));
        }

        [TestMethod]
        public void Test_NextPermutation()
        {
            var res = new int[] { 1, 3, 2 };
            Algorithms.ArrayProb.Arrays.NextPermutation(res);
            CollectionAssert.AreEqual(new int[] { 2, 1, 3 }, res);

            res = new int[] { 1, 2, 3 };
            Algorithms.ArrayProb.Arrays.NextPermutation(res);
            CollectionAssert.AreEqual(new int[] { 1, 3, 2 }, res);
        }

        [TestMethod]
        public void Test_GetPermutation()
        {
            var res = Algorithms.ArrayProb.Arrays.GetPermutation(3, 2);
        }

        [TestMethod]
        public void Test_SubarraySum()
        {
            Assert.AreEqual(3, Algorithms.ArrayProb.Arrays.SubarraySum(new int[] { 1, 1, 1, 1, 1 }, 3));
        }

        [TestMethod]
        public void Test_FindMinArrowShots()
        {
            int[,] arr = new int[,]
            {
                { 10, 16 },
                { 2, 8},
                { 1,   6},
                { 7, 12}                
            };

            Assert.AreEqual(2, Algorithms.ArrayProb.Arrays.FindMinArrowShots(arr));
        }

        [TestMethod]
        public void Test_LeastInterval()
        {
            Assert.AreEqual(8, Algorithms.ArrayProb.Arrays.LeastInterval(new char[] { 'A', 'A', 'B', 'A', 'B', 'B' }, 2));
        }
    }
}
