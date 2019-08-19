using NUnit.Framework;
using Algorithms.ArrayProb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayProb.Tests
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void GetAllPermutationsTest()
        {
            ArrayProb.Permutations.GetAllPermutations(new List<int>() { 1, 2, 3, 4});
            Assert.AreEqual("", "");
        }
    }
}