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
            if(cur.Count == nums.Length)
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

        //https://leetcode.com/problems/next-permutation/description/
        //https://leetcode.com/problems/permutations-ii/description/
        //https://leetcode.com/problems/permutation-sequence/description/
        //https://leetcode.com/problems/combinations/description/
    }
}
