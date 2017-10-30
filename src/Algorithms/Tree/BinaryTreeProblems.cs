using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree
{
    public class BinaryTreeProblems
    {
        /// <summary>
        /// Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.
        /// You need to merge them into a new binary tree.The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.Otherwise, the NOT null node will be used as the node of new tree.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;

            var newNode = new TreeNode(t1.val + t2.val);
            newNode.left = MergeTrees(t1.left, t2.left);
            newNode.right = MergeTrees(t1.right, t2.right);

            return newNode;
        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            InorderHelper(root, ret);
            return ret;
        }

        private static void InorderHelper(TreeNode root, IList<int> ret)
        {
            if (root == null) return;

            InorderHelper(root.left, ret);
            ret.Add(root.val);
            InorderHelper(root.right, ret);
        }

        public static IList<int> IterativeInorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null) return ret;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            var node = root;
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
            while (stack.Any())
            {
                node = stack.Pop();
                ret.Add(node.val);
                if (node.right != null)
                {
                    node = node.right;
                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.left;
                    }
                }
            }

            return ret;
        }


        public static IList<int> MorrisInorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null) return ret;

            var curr = root;
            TreeNode pre = null;

            while (curr != null)
            {
                if (curr.left == null)
                {
                    //does not have left child
                    ret.Add(curr.val);
                    //go to the right child
                    curr = curr.right;
                }
                else
                {
                    //inorder predecessor of current
                    pre = curr.left;
                    while (pre.right != null && pre.right != curr)
                    {
                        pre = pre.right;
                    }

                    // make right child of predecessor to be current
                    if (pre.right == null)
                    {
                        pre.right = curr;
                        curr = curr.left;
                    }
                    //revert changes made
                    else
                    {
                        pre.right = null;
                        ret.Add(curr.val);
                        curr = curr.right;
                    }
                }
            }

            return ret;
        }
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            PreorderHelper(root, ret);
            return ret;
        }

        private static void PreorderHelper(TreeNode root, IList<int> ret)
        {
            if (root == null) return;

            ret.Add(root.val);
            PreorderHelper(root.left, ret);
            PreorderHelper(root.right, ret);
        }

        public static IList<int> IterativePreorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null) return ret;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            var node = root;
            stack.Push(root);
            while (stack.Any())
            {
                node = stack.Pop();
                ret.Add(node.val);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }

            return ret;
        }


        public static IList<int> MorrisPreorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null) return ret;

            var curr = root;
            TreeNode pre = null;

            while (curr != null)
            {
                if (curr.left != null)
                {
                    // keep prev
                    pre = curr.left;
                    while (pre.right != null && pre.right != curr)
                    {
                        pre = pre.right;
                    }

                    if (pre.right == curr)
                    {
                        curr = curr.right;
                        pre.right = null;
                    }
                    else
                    {
                        pre.right = curr;
                        ret.Add(curr.val);
                        curr = curr.left;
                    }
                }
                else
                {
                    ret.Add(curr.val);
                    curr = curr.right;
                }
            }

            return ret;
        }
        public static IList<int> PostorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            PostorderHelper(root, ret);
            return ret;
        }

        private static void PostorderHelper(TreeNode root, IList<int> ret)
        {
            if (root == null) return;

            PostorderHelper(root.left, ret);
            PostorderHelper(root.right, ret);
            ret.Add(root.val);
        }

        public static IList<int> IterativePostorderTraversalUsing2Stack(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null) return ret;

            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            stack1.Push(root);
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            while (stack1.Any())
            {
                var tmp = stack1.Pop();
                stack2.Push(tmp);
                if (tmp.left != null)
                {
                    stack1.Push(tmp.left);
                }
                if (tmp.right != null)
                {
                    stack1.Push(tmp.right);
                }
            }

            while (stack2.Any())
            {
                ret.Add(stack2.Pop().val);
            }

            return ret;
        }

        public static IList<int> IterativePostorderTraversalUsing1Stack(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null) return ret;

            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            stack1.Push(root);
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            while (stack1.Any())
            {
                var tmp = stack1.Pop();
                stack2.Push(tmp);
                if (tmp.left != null)
                {
                    stack1.Push(tmp.left);
                }
                if (tmp.right != null)
                {
                    stack1.Push(tmp.right);
                }
            }

            while (stack2.Any())
            {
                ret.Add(stack2.Pop().val);
            }

            return ret;
        }


        public static IList<int> MorrisPostorderTraversal(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null) return ret;

            var curr = root;
            TreeNode pre = null;

            while (curr != null)
            {
                if (curr.left != null)
                {
                    // keep prev
                    pre = curr.left;
                    while (pre.right != null && pre.right != curr)
                    {
                        pre = pre.right;
                    }

                    if (pre.right == curr)
                    {
                        curr = curr.right;
                        pre.right = null;
                    }
                    else
                    {
                        pre.right = curr;
                        ret.Add(curr.val);
                        curr = curr.left;
                    }
                }
                else
                {
                    ret.Add(curr.val);
                    curr = curr.right;
                }
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/average-of-levels-in-binary-tree/#/description
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<double> AverageOfLevels(TreeNode root)
        {
            var ret = new List<double>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(null);
            var count = 0;
            var total = 0.0;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current != null)
                {
                    total += current.val;
                    count++;
                    if (queue.Peek() == null)
                    {
                        ret.Add(total / count);
                        total = 0; count = 0;
                    }
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                }
                else
                {
                    queue.Enqueue(null);
                    if (queue.Peek() == null)
                    {
                        break;
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/construct-string-from-binary-tree/#/description
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Tree2str(TreeNode t)
        {
            StringBuilder builder = new StringBuilder();
            PreorderPrint(t, builder);
            return builder.ToString();
        }

        private static void PreorderPrint(TreeNode t, StringBuilder builder)
        {
            if (t == null) { builder.Append(""); return; }
            else builder.Append(t.val);

            if (t.left != null || t.left == null && t.right != null)
            {
                builder.Append("(");
                PreorderPrint(t.left, builder);
                builder.Append(")");
            }

            if (t.right != null)
            {
                builder.Append("(");
                PreorderPrint(t.right, builder);
                builder.Append(")");
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/invert-binary-tree/#/description
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var left = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(left);

            return root;
        }

        /// <summary>
        /// https://leetcode.com/problems/sum-of-left-leaves/#/description
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;
            return FindLeftLeaveValues(root, root);
        }

        private static int FindLeftLeaveValues(TreeNode currentNode, TreeNode parent)
        {
            if (currentNode != null && parent.left == currentNode && currentNode.left == null && currentNode.right == null)
            {
                return currentNode.val;
            }

            var ret = 0;
            if (currentNode.left != null)
                ret += FindLeftLeaveValues(currentNode.left, currentNode);
            if (currentNode.right != null)
                ret += FindLeftLeaveValues(currentNode.right, currentNode);

            return ret;
        }

        public static int MaxDepth(TreeNode root, int depth)
        {
            if (root == null) return depth;

            depth++;

            var left = MaxDepth(root.left, depth);
            var right = MaxDepth(root.right, depth);

            return Math.Max(left, right);
        }

        /// <summary>
        /// https://leetcode.com/problems/diameter-of-binary-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            int max = 0;
            DiameterOfBinaryTree(root, ref max);
            return max;
        }

        public static void DiameterOfBinaryTree(TreeNode root, ref int max)
        {
            if (root == null) return;
            var current = MaxDepth(root.left, 0) + MaxDepth(root.right, 0);
            max = Math.Max(current, max);
            DiameterOfBinaryTree(root.left, ref max);
            DiameterOfBinaryTree(root.right, ref max);
        }

        /// <summary>
        /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return createNode(nums, 0, nums.Length - 1);
        }

        private static TreeNode createNode(int[] nums, int head, int tail)
        {
            if (head > tail) return null;
            else if (head == tail) return new TreeNode(nums[head]);
            int mid = (head + tail) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = createNode(nums, head, mid - 1);
            node.right = createNode(nums, mid + 1, tail);
            return node;
        }

        /// <summary>
        /// https://leetcode.com/problems/path-sum-iii/discuss/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static int pathSum(TreeNode root, int sum)
        {
            Dictionary<int, int> preSum = new Dictionary<int, int>();
            preSum.Add(0, 1);
            return helper(root, 0, sum, preSum);
        }

        public static int helper(TreeNode root, int currSum, int target, Dictionary<int, int> preSum)
        {
            if (root == null)
            {
                return 0;
            }

            currSum += root.val;
            int res = preSum.GetValueOrDefault(currSum - target, 0);
            preSum.AddOrSet(currSum, preSum.GetValueOrDefault(currSum, 0) + 1);

            res += helper(root.left, currSum, target, preSum) + helper(root.right, currSum, target, preSum);
            preSum.AddOrSet(currSum, preSum[currSum] - 1);
            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null) return -1;
            return FindSecondMinimumValue(root, root.val);
        }

        private static int FindSecondMinimumValue(TreeNode root, int rootValue)
        {
            if (root == null) return -1;
            if (root.val > rootValue) return root.val;

            var left = FindSecondMinimumValue(root.left, rootValue);
            var right = FindSecondMinimumValue(root.right, rootValue);
            if (left == -1) return right;
            if (right == -1) return left;
            return Math.Min(left, right);
        }

        /// <summary>
        /// https://leetcode.com/problems/subtree-of-another-tree/description/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null) return false;
            if (IsSameTree(s, t)) return true;

            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private static bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (t == null && s == null) return true;
            if (t == null || s == null) return false;

            if (s.val != t.val) return false;

            return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
        }

        /// <summary>
        /// https://leetcode.com/problems/binary-tree-level-order-traversal-ii/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var ret = new LinkedList<List<int>>();
            LevelOrderBottom(root, 0, ret);
            IList<IList<int>> ret2 = new List<IList<int>>();
            foreach (var item in ret)
            {
                ret2.Add(item);
            }
            return ret2;
        }

        private static void LevelOrderBottom(TreeNode root, int level, LinkedList<List<int>> collection)
        {
            if (root == null) return;
            if (collection.Count < level + 1) collection.AddFirst(new List<int>());

            collection.ElementAt(collection.Count - 1 - level).Add(root.val);
            LevelOrderBottom(root.left, level + 1, collection);
            LevelOrderBottom(root.right, level + 1, collection);
        }

        /// <summary>
        /// https://leetcode.com/problems/binary-tree-level-order-traversal/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var ret = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var tmp = new List<int>();
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    tmp.Add(cur.val);
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
                ret.Add(tmp);
            }

            return ret;
        }

        /// <summary>        
        /// https://leetcode.com/problems/binary-tree-paths/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            var ret = new List<string>();
            BinaryTreePathsHelper(root, new StringBuilder(), ret);
            return ret;
        }

        private static void BinaryTreePathsHelper(TreeNode treeNode, StringBuilder builder, IList<string> ret)
        {
            if (treeNode == null) return;
            builder.Append(treeNode.val);
            if ((treeNode.left == null && treeNode.right == null))
            {
                ret.Add(builder.ToString());
                return;
            }
            if (!(treeNode.left == null && treeNode.right == null))
                builder.Append("->");
            BinaryTreePathsHelper(treeNode.left, new StringBuilder(builder.ToString()), ret);
            BinaryTreePathsHelper(treeNode.right, new StringBuilder(builder.ToString()), ret);
        }

        /// <summary>
        /// https://leetcode.com/problems/symmetric-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsSymmetric(TreeNode root)
        {
            return root == null || IsSymmetricHelper(root.left, root.right);
        }

        public static bool IsSymmetric_Iterative(TreeNode root)
        {
            if (root == null) return true;
            var stack1 = new Stack<TreeNode>();
            stack1.Push(root.left);
            var stack2 = new Stack<TreeNode>();
            stack2.Push(root.right);

            var ret = true;

            while (stack1.Any() && stack2.Any())
            {
                var left = stack1.Pop();
                var right = stack2.Pop();

                if (left == null || right == null) ret = ret && (left == right);
                else
                    ret = ret && left.val == right.val;

                if (!ret) return false;

                if (left != null)
                {
                    stack1.Push(left.left);
                    stack1.Push(left.right);
                }
                if (right != null)
                {
                    stack2.Push(right.right);
                    stack2.Push(right.left);
                }
            }

            if (stack1.Any() || stack2.Any()) return false;

            return ret;
        }

        private static bool IsSymmetricHelper(TreeNode node1, TreeNode node2)
        {
            if (node1 == null || node2 == null) return node1 == node2;

            return node1.val == node2.val && IsSymmetricHelper(node1.left, node2.right) && IsSymmetricHelper(node1.right, node2.left);
        }

        /// <summary>
        /// https://leetcode.com/problems/balanced-binary-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            int left = MaxDepth(root.left, 0);
            int right = MaxDepth(root.right, 0);

            return Math.Abs(left - right) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        public static bool IsBalancedBottomUp(TreeNode root)
        {
            return dfsHeight(root) != -1;
        }

        public static int dfsHeight(TreeNode node)
        {
            if (node == null) return 0;

            int left = dfsHeight(node.left);
            if (left == -1) return left;
            int right = dfsHeight(node.right);
            if (right == -1) return right;

            if (Math.Abs(left - right) > 1) return -1;
            return Math.Max(left, right) + 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/path-sum/description/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return sum == 0;
            if (root.left == null && root.right == null && sum - root.val == 0) return true;
            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }

        /// <summary>
        /// https://leetcode.com/problems/path-sum-ii/description/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var ret = new List<IList<int>>();
            void LocalHelper(TreeNode node, IList<int> path, int curSum)
            {
                if (node == null) return;
                path.Add(node.val);
                if (node.left == null && node.right == null && curSum - node.val == 0) ret.Add(path);
                LocalHelper(node.left, new List<int>(path), curSum - node.val);
                LocalHelper(node.right, new List<int>(path), curSum - node.val);
            }

            LocalHelper(root, new List<int>(), sum);
            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MinDepth(TreeNode root)
        {
            return MinDepthHelper(root, 0);
        }

        private static int MinDepthHelper(TreeNode treeNode, int depth)
        {
            if (treeNode == null) return depth;
            int left = MinDepthHelper(treeNode.left, depth);
            int right = MinDepthHelper(treeNode.right, depth);

            return (left == 0 || right == 0) ? left + right + 1 : Math.Min(left, right) + 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var ret = new List<IList<int>>();
            if (root == null) return ret;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var fromRightToLeft = false;
            while (queue.Any())
            {
                var tmp = new List<int>();
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (!fromRightToLeft)
                    {
                        tmp.Add(cur.val);
                    }
                    else
                    {
                        tmp.Insert(0, cur.val);
                    }
                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }
                ret.Add(tmp);
                fromRightToLeft = !fromRightToLeft;
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-univalue-path/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int LongestUnivaluePath(TreeNode root)
        {
            var res = new int[1];
            if (root != null) LongestUnivaluePathHelper(root, res);
            return res[0];
        }

        private static int LongestUnivaluePathHelper(TreeNode root, int[] res)
        {
            int l = root.left != null ? LongestUnivaluePathHelper(root.left, res) : 0;
            int r = root.right != null ? LongestUnivaluePathHelper(root.right, res) : 0;

            int resl = root.left != null && root.val == root.left.val ? l + 1 : 0;
            int resr = root.right != null && root.val == root.right.val ? r + 1 : 0;

            res[0] = Math.Max(res[0], resl + resr);

            return Math.Max(resl, resr);
        }
    }
}
