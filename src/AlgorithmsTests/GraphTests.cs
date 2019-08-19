using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
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
