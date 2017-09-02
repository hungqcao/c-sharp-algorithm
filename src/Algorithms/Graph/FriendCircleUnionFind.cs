using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    /// <summary>
    /// https://leetcode.com/problems/friend-circles/description/
    /// </summary>
    public class FriendCircleUnionFind : UnionFind<int>
    {
        public Dictionary<int, UnionFindItem<int>> ListItem { get; set; }

        public int Count { get; set; }

        public void Init(int[,] nums)
        {
            Count = nums.GetLength(0);
            ListItem = new Dictionary<int, UnionFindItem<int>>();
            for (int i = 0; i <= nums.GetUpperBound(0); i++)
            {
                var item = new UnionFindItem<int>(i);
                this.MakeSet(item);
                ListItem.Add(i, item);
            }
        }

        public new void Union(UnionFindItem<int> x, UnionFindItem<int> y)
        {
            var xRoot = Find(x);
            var yRoot = Find(y);

            if (xRoot == yRoot) return;

            if (xRoot.Rank < yRoot.Rank) xRoot.Parent = yRoot;
            else if (xRoot.Rank > yRoot.Rank) yRoot.Parent = xRoot;
            else
            {
                xRoot.Parent = yRoot;
                yRoot.Rank++;
            }
            this.Count--;
        }

        public int FindCircleNum(int[,] M)
        {
            this.Init(M);
            // Get all bounds before looping.
            int bound0 = M.GetUpperBound(0);
            int bound1 = M.GetUpperBound(1);
            // ... Loop over bounds.
            for (int i = 0; i <= bound0; i++)
            {
                for (int x = 0; x <= bound1; x++)
                {
                    if (M[i, x] == 1)
                    {
                        this.Union(this.ListItem[i], this.ListItem[x]);
                    }
                }
            }

            return this.Count;
        }

    }
}
