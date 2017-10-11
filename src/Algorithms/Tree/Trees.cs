using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tree
{
    public class GNode
    {
        public GNode[] Children { get; set; }
        public GNode Right { get; set; }

        public int Value { get; set; }

        public GNode(int val)
        {
            Value = val;
            Children = new GNode[] { };
        }
    }

    public class Trees
    {
        public static void Connect(GNode root)
        {
            if (root == null) return;

            // Firstly, we connect all children under same root
            for (int i = 0; i < root.Children.Length - 1; i++)
            {
                root.Children[i].Right = root.Children[i + 1];
            }

            // Secondly, we connect the last child with the first children if the node that's in the same level with root
            if(root.Right != null && root.Children.Length > 0)
            {
                var nextRight = root.Right;
                while(nextRight != null)
                {
                    if(nextRight.Children.Length > 0)
                    {
                        // if the next right node has at least 1 child then connect it.
                        root.Children[root.Children.Length - 1].Right = nextRight.Children[0];
                        break;
                    }
                    else
                    {
                        // we move to the next right's right
                        nextRight = nextRight.Right;
                    }
                }
            }

            // Recursively connect each child node
            for (int i = 0; i < root.Children.Length; i++)
            {
                Connect(root.Children[i]);
            }
        }
    }
}
