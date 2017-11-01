using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Number;

namespace UnitTestProject
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void Test_JudgeSquareSum()
        {
            var output = NumberProblems.JudgeSquareSum(5);
            Assert.AreEqual(true, output);
            output = NumberProblems.JudgeSquareSum(4);
            Assert.AreEqual(true, output);
            output = NumberProblems.JudgeSquareSum(2);
            Assert.AreEqual(true, output);
        }
    }
}
