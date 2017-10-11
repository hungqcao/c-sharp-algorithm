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
            Assert.AreEqual(3, Algorithms.Array.Arrays.FindLengthOfLCIS(new int[] { 1, 3, 5, 4, 7 }));
            Assert.AreEqual(1, Algorithms.Array.Arrays.FindLengthOfLCIS(new int[] { 2, 2, 2, 2, 2 }));
            Assert.AreEqual(5, Algorithms.Array.Arrays.FindLengthOfLCIS(new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(1, Algorithms.Array.Arrays.FindLengthOfLCIS(new int[] { 3, 2, 1 }));
            Assert.AreEqual(6, Algorithms.Array.Arrays.FindLengthOfLCIS(new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 5, 6 }));
        }
    }
}
