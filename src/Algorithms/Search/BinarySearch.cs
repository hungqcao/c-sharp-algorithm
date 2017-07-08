using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Search
{
    public class BinarySearch
    {
        /// <summary>
        /// instead of return -1 we return the index that item is supposed to be in
        /// </summary>
        /// <param name="a"></param>
        /// <param name="item"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int binarySearch(int[] a, int item, int low, int high)
        {
            if (high <= low)
                return (item > a[low]) ? (low + 1) : low;

            int mid = (low + high) / 2;

            if (item == a[mid])
                return mid + 1;

            if (item > a[mid])
                return binarySearch(a, item, mid + 1, high);
            return binarySearch(a, item, low, mid - 1);
        }
    }
}
