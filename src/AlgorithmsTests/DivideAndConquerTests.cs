using System;
using NUnit.Framework;
using Algorithms.DivideAndConquer;

namespace UnitTestProject
{
    [TestFixture]
    public class DivideAndConquerTests
    {
        [Test]
        public void Test_DiffWaysToCompute()
        {
            Assert.AreEqual(2,DivideAndConquer.DiffWaysToCompute("2-1-1").Count);
            Assert.AreEqual(5, DivideAndConquer.DiffWaysToCompute("2*3-4*5").Count);
        }
    }
}
