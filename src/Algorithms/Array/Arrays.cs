using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Array
{
    public class Arrays
    {
        /// <summary>
        /// Rotate array with number k
        /// Arrays.Rotate(new int[] { 1, 2 }, 0);
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static void Rotate(int[] nums, int d)
        {
            //if (nums.Length <= 1)
            //    return;
            //var gcd = findGCD(k, nums.Length);
            //for (int i = 0; i < gcd; i++)
            //{
            //    var swapPos = i;
            //    var current = i;
            //    while (swapPos + gcd < nums.Length)
            //    {
            //        swapPos += gcd;
            //        swapItemInArray(nums, current, swapPos);
            //        current = swapPos;
            //    }
            //}

            int n = nums.Length;
            int i, j, k, temp;
            for (i = 0; i < findGCD(d, n); i++)
            {
                /* move i-th values of blocks */
                temp = nums[i];
                j = i;
                while (true)
                {
                    k = j + d;
                    if (k >= n)
                        k = k - n;
                    if (k == i)
                        break;
                    nums[j] = nums[k];
                    j = k;
                }
                nums[j] = temp;
            }
        }
        public static int findGCD(int a, int b)
        {
            if (b == 0) return a;
            else
            {
                return findGCD(b, a % b);
            }
        }

        public static void swapItemInArray(int[] arr, int index1, int index2)
        {
            var tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
