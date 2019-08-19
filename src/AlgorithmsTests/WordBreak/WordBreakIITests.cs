using NUnit.Framework;
using Algorithms.WordBreak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.WordBreak.Tests
{
    [TestFixture()]
    public class WordBreakIITests
    {
        [Test()]
        public void WordBreakTest()
        {
            var wordBreak = new WordBreakII();
            var input = "catsanddog";
            var list = new string[] { "cat", "cats", "and", "sand", "dog" };
            wordBreak.WordBreak(input, list);
        }


        [Test()]
        public void WordBreakTest_3()
        {
            var wordBreak = new WordBreakII();
            var input = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var list = new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };
            wordBreak.WordBreak(input, list);
        }

        [Test]
        public void Test2()
        {
            var wordBreak = new WordBreakII();
            var input = "pineapplepenapple";
            var list = new string[] { "apple", "pen", "applepen", "pine", "pineapple" };
            wordBreak.WordBreak(input, list);
        }
    }
}