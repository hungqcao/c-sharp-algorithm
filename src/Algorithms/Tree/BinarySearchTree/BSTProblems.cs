using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree
{
    public class BSTProblems
    {
        private static int min = Int32.MaxValue;
        private static TreeNode prev = null;
        /// <summary>
        /// https://leetcode.com/problems/minimum-absolute-difference-in-bst
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int GetMinimumDifferenceRecur(TreeNode root)
        {
            if (root == null)
            {
                return min;
            }
            GetMinimumDifferenceRecur(root.left);

            if (prev != null)
            {
                min = Math.Min(min, Math.Abs(prev.val - root.val));
            }
            prev = root;

            GetMinimumDifferenceRecur(root.right);

            return min;
        }

        public static int GetMinimumDifference(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var cur = root;
            var ret = int.MaxValue;
            TreeNode prev = null;
            while(stack.Any() || cur != null)
            {
                if(cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    cur = stack.Pop();
                    if (prev != null)
                    {
                        ret = Math.Min(ret, cur.val - prev.val);
                    }
                    prev = cur;
                    cur = cur.right;
                }
            }

            return ret;
        }
    }
}
