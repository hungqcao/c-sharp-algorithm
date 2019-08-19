﻿using NUnit.Framework;
using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests
{
    [TestFixture()]
    public class StringUnitTests
    {
        [Test()]
        public void partitionLabelsTest()
        {
            Strings.partitionLabels("ababcbacadefegdehijhklij");
        }

        [Test()]
        public void ScoreOfParenthesesTest()
        {
            var res = Strings.ScoreOfParentheses("(()(()))");
            res = Strings.ScoreOfParentheses("()()");
        }
    }
}