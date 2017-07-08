using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Bit
{
    public class BitManipulation
    {
        public static int GetSum(int a, int b)
        {
            return b == 0 ? a : GetSum(a ^ b, (a & b) << 1);
        }

        /// <summary>
        /// Input: 5
        /// Output: 2
        /// Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int FindComplement(int num)
        {
            //int ret = 0;
            //int mask = 1;
            //while(num > mask && mask > 0)
            //{
            //    if ((num & mask) == 0) ret |= mask;
            //    mask <<= 1;
            //}
            //return ret;

            int index = 1;
            int n = num;
            while (n > 0)
            {
                index++;
                n = n >> 1;
            }

            //11111...111 >> i. Build all 1(s) mask
            return num ^ (Int32.MaxValue >> (32 - index));
        }
    }
}
