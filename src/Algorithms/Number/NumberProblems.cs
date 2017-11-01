using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Number
{
    public class NumberProblems
    {
        /// <summary>
        /// https://leetcode.com/problems/sum-of-square-numbers/description/
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool JudgeSquareSum(int c)
        {
            int i = 0;
            int j = (int)Math.Sqrt(c);
            while(i <= j)
            {
                var tmp = i * i + j * j;
                if (tmp == c) return true;
                if (tmp > c) j--;
                else i++;
            }

            return false;
        }
    }
}
