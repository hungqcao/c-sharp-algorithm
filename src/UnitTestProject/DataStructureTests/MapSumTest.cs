using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace UnitTestProject.DataStructureTests
{
    [TestClass]
    public class MapSumTest
    {
        private MapSum mapSum;
        public MapSumTest()
        {
            mapSum = new MapSum();
        }

        [TestMethod]
        public void Test_1()
        {
            mapSum.Insert("apple", 3);
            Assert.AreEqual(3, mapSum.Sum("ap"));
            mapSum.Insert("app", 2);
            Assert.AreEqual(5, mapSum.Sum("ap"));
        }
    }
}
