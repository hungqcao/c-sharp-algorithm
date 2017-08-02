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

        public void IterativeInOrderTraverse(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var node = root;
            while (stack.Any() || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    //visit(stack.Pop());
                    node = node.right;
                }
            }
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
    }
}
