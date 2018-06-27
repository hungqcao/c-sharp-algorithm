﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph.Tests
{
    [TestClass()]
    public class GraphTests
    {
        [TestMethod()]
        public void AllPathsSourceTargetTest()
        {
            int[][] jagged = new int[4][];
            jagged[0] = new int[2] { 1, 2 };
            jagged[1] = new int[1] { 3 };
            jagged[2] = new int[1] { 3 };
            jagged[3] = new int[0] { };

            var res = Problems.AllPathsSourceTarget(jagged);
        }
    }
}