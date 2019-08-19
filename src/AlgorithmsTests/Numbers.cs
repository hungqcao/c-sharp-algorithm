using System;
using NUnit.Framework;
using Algorithms.Number;

namespace UnitTestProject
{
    [TestFixture]
    public class NumberTests
    {
        [Test]
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
