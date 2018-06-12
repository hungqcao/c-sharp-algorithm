using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Matrix.Tests
{
    [TestClass()]
    public class MatrixProblemsTests
    {
        [TestMethod()]
        public void ComputeAreaTest()
        {
            var res = MatrixProblems.ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2);
            Assert.AreEqual(45, res);
            res = MatrixProblems.ComputeArea(-2, -2, 2, 2, 3, 3, 4, 4);
            Assert.AreEqual(17, res);
            res = MatrixProblems.ComputeArea(-1500000001, 0, -1500000000, 1, 1500000000, 0, 1500000001, 1);
            Assert.AreEqual(2, res);
        }
    }
}