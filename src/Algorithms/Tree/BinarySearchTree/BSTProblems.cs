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
            while (stack.Any() || cur != null)
            {
                if (cur != null)
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

        /// <summary>
        /// https://leetcode.com/problems/convert-bst-to-greater-tree/#/description
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode ConvertBST(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var current = root;
            var sum = 0;
            while (stack.Any() || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.right;
                }
                else
                {
                    current = stack.Pop();
                    current.val += sum;
                    sum = current.val;
                    current = current.left;
                }
            }

            return root;
        }

        /*
         VSO Tech Screen 2016
A Binary Search Tree (BST) is a binary tree in which the left sub-tree of each node is less than the node and the right sub-tree is greater than the node. A binary search tree in which exactly one node does not satisfy the criteria is call Correction1 Binary Search Tree.  

Write a function that takes the root node of a binary tree containing integers and returns whether that tree is Correction1 Binary Search Tree. If the tree is Correction1 binary search tree - the function prints the value of the node that does not meet criteria.
Example:
      8
    /   \
  3      10

 / \        \

1  9         14

IsCorr1BST  should return true, and print 9.*/
        private static Int32? ret = null;
        public static bool IsCorr1BST(TreeNode root)
        {
            //In order traversal
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            TreeNode pre = null;
            while (stack.Any() || cur != null)
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    TreeNode p = stack.Pop();
                    if (pre != null && p.val <= pre.val)
                    {
                        //if ret != null then we must encounter 2nd incorrect node
                        if (ret != null) return false;
                        else
                        {
                            //keep the wrong node into ret variable
                            ret = pre.val;
                        }
                    }
                    pre = p;
                    cur = p.right;
                }
            }

            //if we came here and ret is null then it means this is valid BST
            if (ret != null) Console.Write(ret);
            return ret != null;
        }

        /// <summary>
        /// 
        ///     8 -> 3
        ///   /   \
        ///  3  -> 10 -> 1
        /// / \      \
        ///1 ->9   -> 14 -> NULL
        public static void connect2(TreeNode root)
        {
            if (root == null)
                return;

            if (root.next == null) root.next = root.left;

            if (root.left != null)
            {
                if (root.right == null)
                {
                    root.left.next = getNextRight(root);
                }
                else
                {
                    root.left.next = root.right;
                    root.right.next = getNextRight(root);
                }
            }
            else if (root.right != null)
            {
                root.right.next = getNextRight(root);
            }

            connect2(root.right);
            connect2(root.left);
        }


        /// <summary>
        /// 
        ///     8 -> null
        ///   /   \
        ///  3  -> 10 -> null
        /// / \      \
        ///1 ->9   -> 14 -> NULL
        /// </summary>
        /// <param name="p"></param>
        public static void connect(TreeNode root)
        {
            if (root == null)
                return;

            if (root.left != null)
            {
                if (root.right == null)
                {
                    root.left.next = getNextRight(root);
                }
                else
                {
                    root.left.next = root.right;
                    root.right.next = getNextRight(root);
                }
            }
            else if (root.right != null)
            {
                root.right.next = getNextRight(root);
            }

            connect(root.right);
            connect(root.left);
        }

        /// <summary>
        /// Get left outer most of next
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static TreeNode getNextRight(TreeNode node)
        {
            TreeNode tmp = node.next;

            while (tmp != null)
            {
                if (tmp.left != null) return tmp.left;
                if (tmp.right != null) return tmp.right;
                tmp = tmp.next;
            }

            return null;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-mode-in-binary-search-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int[] FindMode(TreeNode root)
        {
            max = 0;
            cur = 1;
            prev = null;
            var ret = new List<int>();
            FindModeHelper(root, ret);
            return ret.ToArray();
        }

        private static int max = 0;
        private static int cur = 1;
        private static void FindModeHelper(TreeNode treeNode, List<int> ret)
        {
            if (treeNode == null) return;
            FindModeHelper(treeNode.left, ret);
            if (prev != null)
            {
                if (treeNode.val == prev.val)
                {
                    cur++;
                }
                else cur = 1;
            }
            if (cur > max)
            {
                max = cur;
                ret.Clear();
                ret.Add(treeNode.val);
            }
            else if (cur == max)
            {
                ret.Add(treeNode.val);
            }
            prev = treeNode;
            FindModeHelper(treeNode.right, ret);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<TreeNode> GenerateTrees(int n)
        {
            return GeneratesTreeNodesHelper(1, n);
        }

        private static IList<TreeNode> GeneratesTreeNodesHelper(int start, int end)
        {
            IList<TreeNode> nodes = new List<TreeNode>();
            
            if(start > end)
            {
                nodes.Add(null);
                return nodes;
            }

            if(end == start)
            {
                nodes.Add(new TreeNode(start));
                return nodes;
            }

            for (int i = start; i <= end; i++)
            {
                var lefts = GeneratesTreeNodesHelper(start, i - 1);
                var rights = GeneratesTreeNodesHelper(i + 1, end);
                foreach (var left in lefts)
                {
                    foreach (var right in rights)
                    {
                        var node = new TreeNode(i);
                        node.left = left;
                        node.right = right;
                        nodes.Add(node);
                    }
                }
            }


            return nodes;
        }

        //https://leetcode.com/problems/unique-binary-search-trees/discuss/

    }
}
