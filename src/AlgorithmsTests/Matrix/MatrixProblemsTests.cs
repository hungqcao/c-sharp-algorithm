using NUnit.Framework;
using Algorithms.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Matrix.Tests
{
    [TestFixture()]
    public class MatrixProblemsTests
    {
        [Test()]
        public void ComputeAreaTest()
        {
            var res = MatrixProblems.ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2);
            Assert.AreEqual(45, res);
            res = MatrixProblems.ComputeArea(-2, -2, 2, 2, 3, 3, 4, 4);
            Assert.AreEqual(17, res);
            res = MatrixProblems.ComputeArea(-1500000001, 0, -1500000000, 1, 1500000000, 0, 1500000001, 1);
            Assert.AreEqual(2, res);
        }

        [Test()]
        public void rotateImageTest()
        {
            var arr = new int[3][];
            arr[0] = new int[3] { 1, 2, 3 };
            arr[1] = new int[3] { 4, 5, 6 };
            arr[2] = new int[3] { 7, 8, 9 };

            var res = MatrixProblems.rotateImage(arr);
        }
    }
}