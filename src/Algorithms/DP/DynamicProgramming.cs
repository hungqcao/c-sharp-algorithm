using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DP
{
    public class DynamicProgramming
    {
        /// <summary>
        /// https://leetcode.com/problems/predict-the-winner/discuss/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool PredictTheWinner(int[] nums)
        {
            return PredictTheWinnerHelper(nums, 0, nums.Length - 1, new int?[nums.Length, nums.Length]) >= 0;
        }

        public static int PredictTheWinnerHelper(int[] nums, int op1, int op2, int?[,] dp)
        {
            if (dp[op1, op2] == null)
            {
                dp[op1, op2] = op1 == op2 ? nums[op1] : Math.Max(nums[op1] - PredictTheWinnerHelper(nums, op1 + 1, op2, dp), nums[op2] - PredictTheWinnerHelper(nums, op1, op2 - 1, dp));
            }
            return dp[op1, op2].Value;
        }
    }
}
