using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests
{
    [TestClass()]
    public class StringUnitTests
    {
        [TestMethod()]
        public void partitionLabelsTest()
        {
            Strings.partitionLabels("ababcbacadefegdehijhklij");
        }

        [TestMethod()]
        public void ScoreOfParenthesesTest()
        {
            var res = Strings.ScoreOfParentheses("(()(()))");
            res = Strings.ScoreOfParentheses("()()");
        }
    }
}