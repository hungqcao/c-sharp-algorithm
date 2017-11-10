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

        /// <summary>
        /// https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/discuss/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int kthSmallest(int[,] matrix, int k)
        {
            int lo = matrix[0, 0], hi = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] + 1;//[lo, hi)
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int count = 0, j = matrix.GetLength(1) - 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    while (j >= 0 && matrix[i, j] > mid) j--;
                    count += (j + 1);
                }
                if (count < k) lo = mid + 1;
                else hi = mid;
            }
            return lo;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin(int[] nums)
        {
            int start = 0, end = nums.Length - 1;
            while (start < end)
            {
                if (nums[start] < nums[end])
                {
                    //sorted
                    return nums[start];
                }

                // nums[start] >= nums[end]
                int mid = (start + end) / 2;
                if (nums[mid] >= nums[start])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }

            return nums[start];
        }

        /// <summary>
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;
            while (start < end)
            {
                if (nums[start] < nums[end])
                {
                    //sorted
                    break;
                }
                int mid = (start + end) / 2;
                if (nums[mid] >= nums[start])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }

            int rot = start;
            // start = end = minimum in sorted array
            start = 0;
            end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                int realMid = (mid + rot) % nums.Length;
                if (nums[realMid] == target) return realMid;
                else if (nums[realMid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchAllowDupp(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] == target) return true;

                // the only difference from the first one, trickly case, just updat left and right
                if ((nums[start] == nums[mid]) && (nums[end] == nums[mid])) { ++start; --end; }
                else if(nums[start] <= nums[mid])
                {
                    if(nums[mid] > target && nums[start] <= target)
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if(nums[mid] < target && target <= nums[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return false;
        }

        //https://leetcode.com/problems/is-subsequence/description/
        //https://leetcode.com/problems/subarray-sum-equals-k/description/
    }
}
