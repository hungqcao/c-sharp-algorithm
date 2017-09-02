using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Backtracking
{
    class BackTrackingProblems
    {
        /// <summary>
        /// https://leetcode.com/problems/generate-parentheses/description/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<string> generateParenthesis(int n)
        {
            List<string> list = new List<string>();
            backtrack(list, "", 0, 0, n);
            return list;
        }

        public void backtrack(List<string> list, string str, int open, int close, int max)
        {
            if (open + close == max << 1)
            {
                list.Add(str);
                return;
            }

            if (open < max)
                backtrack(list, str + "(", open + 1, close, max);
            if (close < open)
                backtrack(list, str + ")", open, close + 1, max);
        }
    }
}
