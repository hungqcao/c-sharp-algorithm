using System;
using NUnit.Framework;
using Algorithms.DataStructures;

namespace UnitTestProject.DataStructureTests
{
    [TestFixture]
    public class MapSumTest
    {
        private MapSum mapSum;
        public MapSumTest()
        {
            mapSum = new MapSum();
        }

        [Test]
        public void Test_1()
        {
            mapSum.Insert("apple", 3);
            Assert.AreEqual(3, mapSum.Sum("ap"));
            mapSum.Insert("app", 2);
            Assert.AreEqual(5, mapSum.Sum("ap"));
        }
    }
}
