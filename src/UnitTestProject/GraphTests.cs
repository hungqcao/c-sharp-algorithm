using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void Test_NumIsland()
        {
            char[,] arr = new char[,]
            {
                { '1', '1', '1', '1','0'},
                { '1', '1', '0', '1','0'},
                { '1', '1', '0', '0','0'},
                { '0', '0', '0', '0','0'}
            };

            var output = Algorithms.Graph.Problems.NumIslands(arr);

            arr = new char[,]
           {
                { '1', '1', '0', '0','0'},
                { '1', '1', '0', '0','0'},
                { '0', '0', '1', '0','0'},
                { '0', '0', '0', '1','1'}
           };

            output = Algorithms.Graph.Problems.NumIslands(arr);
        }
    }
}
