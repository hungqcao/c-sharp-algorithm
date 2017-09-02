using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    public class UnionFindItem<T>
    {
        public UnionFindItem<T> Parent { get; set; }
        public int Rank { get; set; }
        public T Value { get; set; }
        public UnionFindItem(T val)
        {
            this.Value = val;
        }
    }
    public class UnionFind<T>
    {
        public void MakeSet(UnionFindItem<T> item)
        {
            item.Rank = 0;
            item.Parent = item;
        }

        public UnionFindItem<T> Find(UnionFindItem<T> x)
        {
            if(x.Parent != x)
            {
                return Find(x.Parent);
            }
            return x.Parent;
        }

        public void Union(UnionFindItem<T> x, UnionFindItem<T> y)
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
        }
    }
}
