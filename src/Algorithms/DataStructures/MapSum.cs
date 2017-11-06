using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class MapSum
    {
        private SortedDictionary<string, int> sortedDictionary;

        /** Initialize your data structure here. */
        public MapSum()
        {
            sortedDictionary = new SortedDictionary<string, int>();
        }

        public void Insert(string key, int val)
        {
            if (sortedDictionary.ContainsKey(key))
            {
                sortedDictionary[key] = val;
            }
            else
            {
                sortedDictionary.Add(key, val);
            }
        }

        public int Sum(string prefix)
        {
            var items = sortedDictionary.Where(_ => _.Key.StartsWith(prefix));
            return items.Any() ? items.Sum(_ => _.Value) : 0;
        }
    }

    /**
     * Your MapSum object will be instantiated and called as such:
     * MapSum obj = new MapSum();
     * obj.Insert(key,val);
     * int param_2 = obj.Sum(prefix);
     */
}
