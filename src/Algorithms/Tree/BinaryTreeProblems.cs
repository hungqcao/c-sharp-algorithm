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

            while(curr != null)
            {
                if(curr.left == null)
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
                    while(pre.right != null && pre.right != curr)
                    {
                        pre = pre.right;
                    }

                    // make right child of predecessor to be current
                    if(pre.right == null)
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
                    while(pre.right != null && pre.right != curr)
                    {
                        pre = pre.right;
                    }
                    
                    if(pre.right == curr)
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
            while(queue.Any())
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
            if(currentNode != null && parent.left == currentNode && currentNode.left == null && currentNode.right == null)
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
    }
}
