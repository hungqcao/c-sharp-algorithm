using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// 0.15
    /// 4
    /// Item1 Item2 0.1
    /// Item2 Item3 0.2
    /// Item3 Item4 0.1
    /// </summary>
    class Item
    {
        public string Name { get; set; }
        public Item Parent { get; set; }
        public int Size { get; set; }
        public Item SetId { get; set; }
        public int Height { get; set; }
        public Item(string name)
        {
            Name = name;
            SetId = this;
        }
    }

    class UnionFind
    {
        static void MakeSet(Item item)
        {
            item.Parent = item;
            item.Size = 1;
            item.Height = 1;
            item.SetId = item;
        }

        static Item Find(Item item)
        {
            if (item.Parent != item)
            {
                return Find(item.Parent);
            }
            else
            {
                return item;
            }
        }

        static Item Union(Item item1, Item item2)
        {
            var itemParent1 = Find(item1);
            var itemParent2 = Find(item2);

            if (itemParent1 == itemParent2)
            {
                return itemParent1;
            }

            Item setId = null;
            if (itemParent1.SetId.Name.CompareTo(itemParent2.SetId.Name) > 0)
            {
                setId = itemParent2.SetId;
            }
            else
            {
                setId = itemParent1.SetId;
            }

            if (itemParent1.Height > itemParent2.Height)
            {
                itemParent2.Parent = itemParent1;
                itemParent1.SetId = setId;
                itemParent1.Size += itemParent2.Size;
                return itemParent1;
            }
            else if (itemParent1.Height < itemParent2.Height)
            {
                itemParent1.Parent = itemParent2;
                itemParent2.SetId = setId;
                itemParent2.Size += itemParent1.Size;
            }
            else
            {
                itemParent1.Parent = itemParent2;
                itemParent2.Height++;
                itemParent2.SetId = setId;
                itemParent2.Size += itemParent1.Size;
            }

            return itemParent2;
        }
        static Item GetOrCreateNew(Dictionary<string, Item> dictItem, string name)
        {
            Item item = null;

            if (dictItem.TryGetValue(name, out item))
            {
                return item;
            }
            else
            {
                var result = new Item(name);
                MakeSet(result);
                dictItem.Add(name, result);
                return result;
            }
        }
        static Item UpdateResult(Item result, Item parentItem)
        {
            if (parentItem.Size > result.Size)
            {
                return parentItem;
            }
            else if (parentItem.Size == result.Size)
            {
                if (parentItem.SetId.Name.CompareTo(result.SetId.Name) > 0)
                {
                    return result;
                }
                else
                {
                    return parentItem;
                }
            }
            else
            {
                return result;
            }
        }

        //static void Main(string[] args)
        //{
        //    /* Enter your code here. Read input from STDIN. Print output to STDOUT */
        //    double threshHold = Double.Parse(Console.ReadLine());
        //    int n = int.Parse(Console.ReadLine());
        //    Item result = new Item(string.Empty);

        //    Dictionary<string, Item> dictItem = new Dictionary<string, Item>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        string[] str = Console.ReadLine().Split(' ');
        //        double affProb = Double.Parse(str[2]);
        //        var itemLeft = GetOrCreateNew(dictItem, str[0]);
        //        result = UpdateResult(result, itemLeft);
        //        var itemRight = GetOrCreateNew(dictItem, str[1]);
        //        result = UpdateResult(result, itemRight);
        //        if (affProb >= threshHold)
        //        {
        //            var parentItem = Union(itemLeft, itemRight);
        //            result = UpdateResult(result, parentItem);
        //        }
        //    }

        //    Console.WriteLine(result.SetId.Name);
        //}
    }
}
