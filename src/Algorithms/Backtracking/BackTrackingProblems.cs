using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Backtracking
{
    public class BackTrackingProblems
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

        /// <summary>
        /// https://leetcode.com/problems/combination-sum-iii/description/
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            combinationSum3Ret = new List<IList<int>>();
            CombinartionSum3Helper(new List<int>(), 1, k, n);
            return combinationSum3Ret;
        }

        private static IList<IList<int>> combinationSum3Ret;
        private static void CombinartionSum3Helper(IList<int> cur, int curNum, int k, int n)
        {
            if (cur.Sum() == n && cur.Count == k)
            {
                combinationSum3Ret.Add(cur);
                return;
            }

            if (cur.Count >= k) return;

            for (int i = curNum; i <= 9; i++)
            {
                cur.Add(i);
                CombinartionSum3Helper(new List<int>(cur), i + 1, k, n);
                cur.Remove(i);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/permutations/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Permute(int[] nums)
        {
            var ret = new List<IList<int>>();
            PermuteHelper(nums, new List<int>(), ret);
            return ret;
        }

        private static void PermuteHelper(int[] nums, IList<int> cur, IList<IList<int>> ret)
        {
            if (cur.Count == nums.Length)
            {
                var tmp = new List<int>(cur);
                ret.Add(tmp);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (cur.Contains(nums[i])) continue;
                cur.Add(nums[i]);
                PermuteHelper(nums, cur, ret);
                cur.Remove(nums[i]);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/permutations-ii/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            var ret = new List<IList<int>>();
            Array.Sort(nums);
            bool[] used = new bool[nums.Length];
            PermuteUniqueHelper(nums, new List<int>(), used, ret);
            return ret;
        }
        private static void PermuteUniqueHelper(int[] nums, IList<int> cur, bool[] used, IList<IList<int>> ret)
        {
            if (cur.Count == nums.Length)
            {
                var tmp = new List<int>(cur);
                ret.Add(tmp);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i]) continue;
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
                cur.Add(nums[i]);
                used[i] = true;
                PermuteUniqueHelper(nums, cur, used, ret);
                cur.RemoveAt(cur.Count - 1);
                used[i] = false;
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/combinations/description/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IList<IList<int>> Combine(int n, int k)
        {
            var ret = new List<IList<int>>();
            var nums = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                nums.Add(i);
            }

            CombineHelper(nums, new List<int>(), 0, k, ret);
            return ret;
        }

        private static void CombineHelper(IList<int> nums, IList<int> cur, int startIndex, int k, IList<IList<int>> ret)
        {
            if (cur.Count == k)
            {
                var tmp = new List<int>(cur);
                ret.Add(tmp);
                return;
            }

            for (int i = startIndex; i < nums.Count; i++)
            {
                cur.Add(nums[i]);
                CombineHelper(nums, cur, ++startIndex, k, ret);
                cur.RemoveAt(cur.Count - 1);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/combination-sum/description/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var ret = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSumHelper(candidates, new List<int>(),0, 0, target, ret);
            return ret;
        }

        private static void CombinationSumHelper(int[] nums, IList<int> cur, int startIndex, int curSum, int target, IList<IList<int>> ret)
        {
            if (curSum == target)
            {
                var tmp = new List<int>(cur);
                ret.Add(tmp);
                return;
            }

            for (int i = startIndex; i < nums.Length; i++)
            {
                curSum += nums[i];
                if (curSum > target) return;
                cur.Add(nums[i]);
                CombinationSumHelper(nums, cur, i, curSum, target, ret);
                curSum -= nums[i];
                cur.RemoveAt(cur.Count - 1);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/combination-sum-ii/description/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var ret = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSum2Helper(candidates, new List<int>(), 0, 0, target, ret);
            return ret;
        }

        private static void CombinationSum2Helper(int[] nums, IList<int> cur, int startIndex, int curSum, int target, IList<IList<int>> ret)
        {
            if (curSum == target)
            {
                var tmp = new List<int>(cur);
                ret.Add(tmp);
                return;
            }

            for (int i = startIndex; i < nums.Length; i++)
            {
                if (i > startIndex && nums[i] == nums[i - 1])
                    continue;
                curSum += nums[i];
                if (curSum > target) return;
                cur.Add(nums[i]);
                CombinationSumHelper(nums, cur, i+1, curSum, target, ret);
                curSum -= nums[i];
                cur.RemoveAt(cur.Count - 1);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/subsets/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Subsets(int[] nums)
        {
            var ret = new List<IList<int>>();
            Array.Sort(nums);
            SubsetsHelper(nums, new List<int>(), 0, ret);
            return ret;
        }

        private static void SubsetsHelper(int[] nums, IList<int> tmp, int start, IList<IList<int>> ret)
        {
            ret.Add(new List<int>(tmp));
            for (int i = start; i < nums.Length; i++)
            {
                tmp.Add(nums[i]);
                SubsetsHelper(nums, tmp, i + 1, ret);
                tmp.RemoveAt(nums.Length - 1);
            }
        }
    }
}
