using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.LinkedLists
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod_CalPoints()
        {
            Assert.AreEqual(Algorithms.LinkedList.LinkedList.CalPoints(new string[] { "5", "2", "C", "D", "+" }), 30);
            Assert.AreEqual(Algorithms.LinkedList.LinkedList.CalPoints(new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" }), 27);
        }
    }
}
