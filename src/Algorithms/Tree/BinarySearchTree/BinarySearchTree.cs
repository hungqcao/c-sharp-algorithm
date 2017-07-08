using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree.BinarySearchTree
{
    public class BinarySearchTree
    {
        public TreeNode Root { get; set; }
        public BinarySearchTree()
        {

        }

        public BinarySearchTree(TreeNode root)
        {
            this.Root = root;
        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
                return;
            }
            else
            {
                TreeNode temp = Root;
                while (temp != null)
                {
                    if (value <= temp.val)
                    {
                        if (temp.left == null)
                        {
                            temp.left = new TreeNode(value);
                            return;
                        }
                        else
                        {
                            temp = temp.left;
                        }
                    }
                    else
                    {
                        if (temp.right == null)
                        {
                            temp.right = new TreeNode(value);
                            return;
                        }
                        else
                        {
                            temp = temp.right;
                        }
                    }
                }
            }
        }

        public bool Find(int value, TreeNode root)
        {
            return FindNode(value, root) != null;
        }

        public TreeNode FindNode(int value, TreeNode root)
        {
            if (root == null)
                return null;

            if (root.val == value)
            {
                return root;
            }
            else if (value > root.val)
            {
                return FindNode(value, root.right);
            }
            else
            {
                return FindNode(value, root.left);
            }
        }

        public void Remove(int value)
        {
            var node = FindNode(value, Root);
        }

        public void Remove(TreeNode node)
        {
            if (node == null) return;

            if (node.left == null && node.right == null)
            {
                node = null;
            }
            //else if()
        }

        public void Print()
        {
            if (Root == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode temp = Root;
            while(temp != null)
            {
                //Look at left subtree first
                stack.Push(temp);
                temp = temp.left;
            }

            while (stack.Any())
            {
                var node = stack.Pop();
                Console.Write($"{node.val} ");
                if(node.right != null)
                {
                    node = node.right;
                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.left;
                    }
                }
            }
        }

        public void Main()
        {
            var tree = new BinarySearchTree();
            tree.Insert(1);
            tree.Insert(8);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(5);
            tree.Insert(4);
            tree.Print();
        }
    }
}
