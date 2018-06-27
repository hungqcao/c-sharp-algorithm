using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.ArrayProb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayProb.Tests
{
    [TestClass()]
    public class ArrayUnitTest
    {
        [TestMethod()]
        public void firstNotRepeatingCharacterTest()
        {
            var res = Arrays.firstNotRepeatingCharacter("abacabad");
            Assert.AreEqual('c', res);
        }
    }
}