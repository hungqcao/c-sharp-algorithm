using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Utils
    {
        public static void Swap<T>(this T[] source, int left, int right)
        {
            T tmp = source[left];
            source[left] = source[right];
            source[right] = tmp;
        }


        public static void Swap(int[] nums, int left, int right)
        {
            int tmp = nums[left];
            nums[left] = nums[right];
            nums[right] = tmp;
        }
    }
}
