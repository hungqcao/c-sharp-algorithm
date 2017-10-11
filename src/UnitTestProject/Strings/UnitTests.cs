using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Strings
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod_JudgeCircle()
        {
            var input = "LL";
            Assert.AreEqual(Algorithms.Strings.JudgeCircle(input), false);
        }
    }
}
