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
                if (target >= nums[i])
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
            int[] dp = new int[n + 1];
            dp[0] = dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j];
                }
            }
            return dp[n];
        }

        /// <summary>
        /// https://leetcode.com/problems/coin-change/description/
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = amount + 1;
            }

            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

        /// <summary>
        /// https://leetcode.com/problems/partition-equal-subset-sum/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanPartition(int[] nums)
        {
            int sum = 0;

            foreach (int num in nums)
            {
                sum += num;
            }

            if ((sum & 1) == 1)
            {
                return false;
            }
            sum /= 2;

            int n = nums.Length;
            bool[] dp = new bool[sum + 1];
            dp[0] = true;

            foreach (var num in nums)
            {
                for (int i = sum; i > 0; i--)
                {
                    if (i >= num)
                    {
                        dp[i] = dp[i] || dp[i - num];
                    }
                }
            }

            return dp[sum];
        }

        /// <summary>
        /// https://leetcode.com/problems/target-sum/discuss/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public static int FindTargetSumWays(int[] nums, int S)
        {
            int sum = 0;
            foreach (var n in nums)
                sum += n;
            return sum < S || (S + sum) % 2 > 0 ? 0 : subsetSum(nums, (S + sum) >> 1);
        }

        public static int subsetSum(int[] nums, int s)
        {
            int[] dp = new int[s + 1];
            dp[0] = 1;
            foreach (var n in nums)
                for (int i = s; i >= n; i--)
                    dp[i] += dp[i - n];
            return dp[s];
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-palindromic-subsequence/discuss/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestPalindromeSubseq(string s)
        {
            int[,] dp = new int[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = 1;
            }

            for (int len = 1; len <= s.Length; len++)
            {
                //iterate each subtring               
                for (int i = 0; i < s.Length - len; i++)
                {
                    int j = i + len;
                    if (s[i] == s[j])
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[0, s.Length - 1];
        }
    }
}
