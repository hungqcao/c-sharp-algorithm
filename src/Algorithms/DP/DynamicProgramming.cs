using Algorithms.Tree;
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

        /// <summary>
        /// https://leetcode.com/problems/combination-sum-iv/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int CombinationSum4(int[] nums, int target)
        {
            // 2,3,5 | 7
            // Sum 2: [2]
            // Sum 3: [3]
            // Sum 5: [2,3] [3,2] [5]
            // Sum 7: Sum 2 + Sum 3 + Sum 5
            //int ret = 0;
            //if (nums == null || nums.Length == 0) return ret;

            //// base case
            //if (target == 0) return 1;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if(target >= nums[i])
            //        ret += CombinationSum4(nums, target - nums[i]);
            //}

            //return ret;

            // DP

            int ret = 0;
            if (nums == null || nums.Length == 0) return ret;

            int[] dp = new int[target + 1];
            dp[0] = 1;

            return CombinationSum4Helper(nums, dp, target);
        }

        private static int CombinationSum4Helper(int[] nums, int[] dp, int target)
        {
            if (target == 0) return dp[0];

            int ret = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(target >= nums[i])
                {
                    ret += CombinationSum4Helper(nums, dp, target - nums[i]);
                }
            }

            dp[target] = ret;
            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/unique-binary-search-trees/description/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumTrees(int n)
        {

        }
    }
}
