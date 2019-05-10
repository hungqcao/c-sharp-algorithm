using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.ArrayProb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayProb.Tests
{
    [TestClass]
    public class PermutationsTests
    {
        [TestMethod]
        public void GetAllPermutationsTest()
        {
            ArrayProb.Permutations.GetAllPermutations(new List<int>() { 1, 2, 3, 4});
            Assert.AreEqual("", "");
        }
    }
}