using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayProb
{
    public class Arrays
    {
        //Binary search on a sorted array
        public static int bSearch(int[] arr, int number)
        {
            int head = 0;
            int tail = arr.Length - 1;
            while (head < tail)
            {
                int mid = (head + tail) / 2;
                if (arr[mid] == number) return mid;
                else if (arr[mid] > number)
                {
                    tail = mid - 1;
                }
                else
                {
                    head = mid + 1;
                }
            }
            return -1;
        }

        //Find GCD(greatest common divisor)
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

        //Rotate an array
        public static void RotateArrayUsingArray(int[] arr, int n)
        {
            var gcd = findGCD(n, arr.Length);
            for (int i = 0; i < gcd; i++)
            {
                var swapPos = i;
                var current = i;
                while (swapPos + gcd < arr.Length)
                {
                    swapPos += gcd;
                    swapItemInArray(arr, current, swapPos);
                    current = swapPos;
                }
            }
        }

        public int findSmallestCommonIn3Array(int[] arr1, int[] arr2, int[] arr3)
        {
            //int i, j, k = 0;
            //while (i < arr1.Length && j < arr2.Length && k < arr2.Length)
            //{
            //    if (arr1[i] == arr2[j] == arr3[k])
            //    {
            //        return arr1[i];
            //    }
            //    else if (arr1[i] < arr2[j])
            //    {
            //        i++;
            //    }
            //    else if (arr2[j] < arr3[k])
            //    {
            //        j++;
            //    }
            //    else
            //    {
            //        k++;
            //    }
            //}
            return -1;
        }

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

        /// <summary>
        /// Input: [1,4,3,2]
        /// Output: 4
        /// Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ArrayPairSum(int[] nums)
        {
            int ret = 0;
            nums = nums.OrderBy(i => i).ToArray();
            for (int i = 0; i < nums.Length; i += 2)
            {
                ret += nums[i];
            }
            return ret;
        }


        /// <summary>
        /// n MATLAB, there is a very useful function called 'reshape', which can reshape a matrix into a new one with different size but keep its original data.
        ///        You're given a matrix represented by a two-dimensional array, and two positive integers r and c representing the row number and column number of the wanted reshaped matrix, respectively.
        ///The reshaped matrix need to be filled with all the elements of the original matrix in the same row-traversing order as they were.
        ///If the 'reshape' operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.
        ///Example 1:
        ///Input: 
        ///nums =
        ///[[1, 2],
        /// [3,4]]
        ///r = 1, c = 4
        ///Output: 
        ///[[1,2,3,4]]
        ///Explanation:
        ///The row-traversing of nums is [1,2,3,4]. The new reshaped matrix is a 1 * 4 matrix, fill it row by row by using the previous list.
        ///https://leetcode.com/problems/reshape-the-matrix/#/description
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            //v1
            //if (nums.GetLength(0) * nums.GetLength(1) != r * c) return nums;
            //var source = nums.Cast<int>().ToArray();
            //var ret = new int[r, c];
            //int currentRow = 0;
            //int currentCol = 0;
            //for (int i = 0; i < source.Length; i++)
            //{
            //    if(currentCol == c)
            //    {
            //        //end of row
            //        currentRow++;
            //        currentCol = 0;
            //    }
            //    ret[currentRow, currentCol] = source[i];
            //    currentCol++;
            //}

            //return ret;

            //v2
            var numRows = nums.GetLength(0);
            var numCols = nums.GetLength(1);

            if (numRows * numCols != r * c)
                return nums;

            var t = new int[r, c];
            int e = 0;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    var newRow = e / c;
                    var newCol = e % c;
                    t[newRow, newCol] = nums[i, j];
                    e++;
                }
            }

            return t;
        }

        /// <summary>
        /// https://leetcode.com/problems/distribute-candies/#/description
        /// </summary>
        /// <param name="candies"></param>
        /// <returns></returns>
        public static int DistributeCandies(int[] candies)
        {
            HashSet<int> set = new HashSet<int>(candies);
            return candies.Length < 1 ? 0 : Math.Min(set.Count, candies.Length / 2);
        }

        /// <summary>
        /// https://leetcode.com/problems/next-greater-element-i/#/description
        /// </summary>
        /// <param name="findNums"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            //Dictionary<int, int> dict = new Dictionary<int, int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    dict.Add(nums[i], -1);//default
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[j] > nums[i])
            //        {
            //            dict[nums[i]] = nums[j];
            //            break;
            //        };
            //    }
            //}
            //var ret = new int[findNums.Length];
            //for (int i = 0; i < findNums.Length; i++)
            //{
            //    ret[i] = dict[findNums[i]];
            //}

            //return ret;

            Dictionary<int, int> map = new Dictionary<int, int>(); // map from x to next greater element of x
            Stack<int> stack = new Stack<int>();
            foreach (int num in nums)
            {
                while (stack.Any() && stack.Peek() < num)
                    map.Add(stack.Pop(), num);
                stack.Push(num);
            }
            for (int i = 0; i < findNums.Length; i++)
                findNums[i] = map.ContainsKey(findNums[i]) ? map[findNums[i]] : -1;
            return findNums;
        }

        /// <summary>
        /// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        /// For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be[1, 3, 12, 0, 0].
        /// https://leetcode.com/problems/move-zeroes/#/description
        /// </summary>
        /// <param name="nums"></param>
        public static void MoveZeroes(int[] nums)
        {
            //int firstZeroIndex = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == 0) {
            //        if(firstZeroIndex > i)
            //        firstZeroIndex = i;
            //    }
            //    else
            //    {
            //        //nums[i] # 0 or firstZeroIndex != -1 (we don't do anything here)
            //        if (nums[i] != 0)
            //        {
            //            nums.Swap(i, firstZeroIndex);
            //            firstZeroIndex++;
            //        }
            //    }
            //}
            if (nums.Length != 0)
            {
                int writeIndex = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        int temp = nums[writeIndex];
                        nums[writeIndex] = nums[i];
                        nums[i] = temp;
                        writeIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/construct-the-rectangle/#/description
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static int[] ConstructRectangle(int area)
        {
            //if(area == 1)
            //{
            //    return new int[] { 1, 1 };
            //}

            //List<IList<int>> source = new List<IList<int>>();

            //for (int i = 1; i <= area / 2; i++)
            //{
            //    if (area % i == 0)
            //    {
            //        IList<int> pair = new List<int>();
            //        var l = Math.Floor(area / i * 1.0);
            //        if (Convert.ToInt32(l) >= i)
            //        {
            //            pair.Add(Convert.ToInt32(l));
            //            pair.Add(i);
            //            source.Add(pair);
            //        }
            //    }
            //}

            //var min = source.Min(_ =>
            //{
            //    return _[0] - _[1];
            //});
            //var ret = source.Find(_ => _[0] - _[1] == min);

            //return ret.ToArray();
            int[] r = new int[2];

            if (area < 0) return r;

            int w = (int)Math.Sqrt(area);

            while (area % w != 0)
            {
                w--;
            }

            r[0] = area / w;
            r[1] = w;

            return r;
        }

        /// <summary>
        /// https://leetcode.com/problems/range-addition-ii/#/description
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="ops"></param>
        /// <returns></returns>
        public static int MaxCount(int m, int n, int[,] ops)
        {
            if (ops.GetLength(0) == 0) return m * n;
            int col = Int32.MaxValue, row = Int32.MaxValue;

            for (int x = 0; x < ops.GetLength(0); x += 1)
            {
                row = Math.Min(row, ops[x, 0]);
                col = Math.Min(col, ops[x, 1]);
            }

            return row * col;
        }

        /// <summary>
        /// https://codefights.com/interview-practice/task/pMvymcahZ8dY4g75q
        /// Given an array a that contains only numbers in the range from 1 to a.length, find the first duplicate number for which the second occurrence has the minimal index. In other words, if there are more than 1 duplicated numbers, return the number for which the second occurrence has a smaller index than the second occurrence of the other number does. If there are no such elements, return -1.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int firstDuplicate(int[] a)
        {
            //Dictionary<int, int> dict = new Dictionary<int, int>();
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (dict.ContainsKey(a[i]))
            //    {
            //        if(dict[a[i]] == -1)
            //            dict[a[i]] = i;
            //    }
            //    else
            //    {
            //        dict.Add(a[i], -1);
            //    }
            //}

            //int ret = -1;
            //int retIndex = int.MaxValue;
            //foreach (var kvp in dict)
            //{
            //    if(kvp.Value != -1)
            //    {
            //        if(retIndex > kvp.Value)
            //        {
            //            ret = kvp.Key;
            //            retIndex = kvp.Value;
            //        }
            //    }
            //}

            //return ret;

            //Sol2:
            for (int i = 0; i < a.Length; i++)
                if (a[Math.Abs(a[i]) - 1] < 0)
                    return Math.Abs(a[i]);
                else
                {
                    a[Math.Abs(a[i]) - 1] = -a[Math.Abs(a[i]) - 1];
                }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/minimum-index-sum-of-two-lists/#/description
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static string[] FindRestaurant(string[] list1, string[] list2)
        {
            //var dict = new Dictionary<string, int>();
            //for (var i = 0; i < list1.Length; i++)
            //{
            //    if (!dict.ContainsKey(list1[i]))
            //    {
            //        dict.Add(list1[i], i - list1.Length);
            //    }
            //}

            //for (int i = 0; i < list2.Length; i++)
            //{
            //    if (dict.ContainsKey(list2[i]))
            //    {
            //        dict[list2[i]] = dict[list2[i]] + list1.Length + i;
            //    }
            //    else
            //    {
            //        dict.Remove(list2[i]);
            //    }
            //}

            //var min = dict.Where(_ => _.Value >= 0).Min(_ => _.Value);
            //return dict.Where(_ => _.Value == min).Select(_ => _.Key).ToArray();
            var dict = new Dictionary<string, int>();
            var result = new List<string>();

            for (int i = 0; i < list1.Length; i++)
            {
                dict.Add(list1[i], i);
            }

            int minSum = Int32.MaxValue;
            for (int i = 0; i < list2.Length; i++)
            {

                if (dict.ContainsKey(list2[i]))
                {
                    var num = dict[list2[i]];
                    if (i + num <= minSum)
                    {
                        if (i + num < minSum)
                        {
                            minSum = i + num;
                            result = new List<string>();
                        }

                        result.Add(list2[i]);
                    }
                }
            }

            return result.ToArray();
        }


        /// <summary>
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/#/description
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum2Pointers(int[] numbers, int target)
        {
            //int[] ret = new int[2];
            //int tail = numbers.Length - 1;
            //int head = 0;
            //for (int i = numbers.Length - 1; i >= 0; i--)
            //{
            //    tail = i;
            //    while (tail > head)
            //    {
            //        if (numbers[tail] + numbers[head] == target)
            //        {
            //            ret[0] = head + 1;
            //            ret[1] = tail + 1;
            //            return ret;
            //        }
            //        else if (numbers[tail] + numbers[head] < target)
            //        {
            //            head++;
            //        }
            //        else
            //        {
            //            head = 0;
            //            break;
            //        }
            //    }
            //}

            //return null;
            int tail = numbers.Length - 1;
            int head = 0;
            while (numbers[head] + numbers[tail] != target)
            {
                if (numbers[head] + numbers[tail] < target)
                {
                    head++;
                }
                else
                {
                    tail--;
                }
            }

            return new int[] { head + 1, tail + 1 };
        }


        /// <summary>
        /// https://leetcode.com/problems/intersection-of-two-arrays/#/description
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            var dict = new HashSet<int>();
            var ret = new HashSet<int>();
            foreach (var item in nums1)
            {
                dict.Add(item);
            }

            foreach (var item in nums2)
            {
                if (dict.Contains(item))
                {
                    ret.Add(item);
                }
            }

            return ret.ToArray();
        }

        /// <summary>
        /// https://leetcode.com/problems/minimum-moves-to-equal-array-elements/#/description
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MinMoves(int[] nums)
        {
            var min = nums.Min();
            int ret = 0;
            foreach (var item in nums)
            {
                ret += item - min;
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/assign-cookies/#/description
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FindContentChildren(int[] g, int[] s)
        {
            int ret = 0;
            g = g.OrderBy(_ => _).ToArray();
            s = s.OrderBy(_ => _).ToArray();
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (j < g.Length)
                {
                    if (s[i] >= g[j]) { ret++; j++; }
                }
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/max-consecutive-ones/#/description
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int ret = 0;
            int start = -1, end = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    if (end == -1) start = i;
                    end = i;
                }
                else
                {
                    if (end != -1 && start != -1)
                    {
                        ret = Math.Max(ret, end - start + 1);
                    }
                    end = -1;
                    start = -1;
                }
            }

            if (end != -1 && start != -1)
            {
                ret = Math.Max(ret, end - start + 1);
            }

            return ret;

            //int localMax = 0;
            //int globalMax = 0;
            //if (nums.Length == 0)
            //    return 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == 0)
            //    {
            //        localMax = 0;
            //    }
            //    else
            //    {
            //        localMax++;
            //    }
            //    globalMax = Math.Max(globalMax, localMax);
            //}
            //return globalMax;
        }

        /// <summary>
        /// https://leetcode.com/problems/first-unique-character-in-a-string/#/description
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FirstUniqChar(string s)
        {
            int[] arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (arr[s[i] - 'a'] == 1)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/number-of-boomerangs/tabs/description
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int NumberOfBoomerangs(int[][] points)
        {
            Func<int[], int[], int> findDistance = (a, b) =>
            {
                int dx = a[0] - b[0];
                int dy = a[1] - b[1];

                return dx * dx + dy * dy;
            };

            int ret = 0;

            var dict = new Dictionary<int, int>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j) continue;
                    var distance = findDistance(points[i], points[j]);
                    if (dict.ContainsKey(distance)) dict[distance]++;
                    else dict.Add(distance, 1);
                }

                foreach (var item in dict)
                {
                    ret += item.Value * (item.Value - 1);
                }

                dict.Clear();
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static IList<string> ReadBinaryWatch(int num)
        {
            if (num == 0) return new List<string>() { "0:00" };
            if (num > 10) return new List<string>();

            Dictionary<int, IList<Tuple<string, string>>> dict = new Dictionary<int, IList<Tuple<string, string>>>();
            var hourFormat = "0000";
            var minuteFormat = "000000";
            for (int i = 1; i <= num; i++)
            {
                if (i == 1)
                {
                    var list1 = new List<Tuple<string, string>>();
                    for (int m = 0; m < 6; m++)
                    {
                        var tmp = minuteFormat.ToArray();
                        tmp[m] = '1';
                        var tup = new Tuple<string, string>(hourFormat, new string(tmp));
                        list1.Add(tup);
                    }
                    for (int h = 0; h < 4; h++)
                    {
                        var tmp = hourFormat.ToArray();
                        tmp[h] = '1';
                        var tup = new Tuple<string, string>(new string(tmp), minuteFormat);
                        list1.Add(tup);
                    }
                    dict.Add(1, list1);
                }
                else
                {
                    var list = new List<Tuple<string, string>>();
                    var prev = dict[i - 1];
                    foreach (var item in prev)
                    {
                        var tmp = item.Item1 + ";" + item.Item2;
                        for (int j = tmp.IndexOf('1'); j < tmp.Length; j++)
                        {
                            if (tmp[j] == ';' || tmp[j] == '1') continue;
                            var tmpArr = tmp.ToArray();
                            tmpArr[j] = '1';
                            list.Add(new Tuple<string, string>(new string(tmpArr).Split(';')[0], new string(tmpArr).Split(';')[1]));
                        }
                    }
                    dict.Add(i, list);
                }
            }

            var ret = new List<string>();
            foreach (var item in dict[num])
            {
                ret.Add(Convert.ToInt32(item.Item1, 2) + ":" + (Convert.ToInt32(item.Item2, 2).ToString().Length == 1 ? "0" + Convert.ToInt32(item.Item2, 2).ToString() : Convert.ToInt32(item.Item2, 2).ToString()));
            }

            return ret.OrderBy(_ => _).ToList();
        }

        /// <summary>
        /// https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                if (dict.ContainsKey(nums2[i])) dict[nums2[i]]++;
                else dict.Add(nums2[i], 1);
            }

            var ret = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (dict.ContainsKey(nums1[i]) && dict[nums1[i]] > 0)
                {
                    dict[nums1[i]]--;
                    ret.Add(nums1[i]);
                }
            }

            return ret.ToArray();
        }

        /// <summary>
        /// https://leetcode.com/problems/product-of-array-except-self/discuss/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] productExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            res[0] = 1;
            for (int i = 1; i < n; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }
            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                res[i] *= right;
                right *= nums[i];
            }
            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-the-duplicate-number/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindDuplicate(int[] nums)
        {
            if (nums.Length > 1)
            {
                int slow = nums[0];
                int fast = nums[nums[0]];
                while (slow != fast)
                {
                    slow = nums[slow];
                    fast = nums[nums[fast]];
                }

                fast = 0;
                while (fast != slow)
                {
                    fast = nums[fast];
                    slow = nums[slow];
                }
                return slow;
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int maxProfit(int[] prices)
        {
            int maxCur = 0, maxSoFar = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                maxCur = Math.Max(0, maxCur += prices[i] - prices[i - 1]);
                maxSoFar = Math.Max(maxCur, maxSoFar);
            }
            return maxSoFar;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-continuous-increasing-subsequence/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || !nums.Any()) return 0;
            var ret = 1;
            var curMax = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1]) curMax++;
                else
                {
                    ret = Math.Max(curMax, ret);
                    curMax = 1;
                }
            }

            return Math.Max(curMax, ret);
        }

        /// <summary>
        /// https://leetcode.com/problems/house-robber/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Rob(int[] nums)
        {
            int rob = 0;
            int norob = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int cur = norob + nums[i];
                norob = Math.Max(norob, rob);
                rob = cur;
            }

            return Math.Max(norob, rob);
        }

        /// <summary>
        /// https://leetcode.com/problems/pascals-triangle/description/
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            var ret = new List<IList<int>>();
            for (int i = 1; i <= numRows; i++)
            {
                var tmp = new List<int>();
                for (int j = 0; j < i; j++)
                {
                    if (j == 0 || j == i - 1) tmp.Add(1);
                    else
                    {
                        tmp.Add(ret[i - 2][j - 1] + ret[i - 2][j]);
                    }
                }
                ret.Add(tmp);
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/maximum-average-subarray-i/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double FindMaxAverage(int[] nums, int k)
        {
            if (k > nums.Length) return 0;

            int curSum = 0;

            for (int i = 0; i < k; i++)
            {
                curSum += nums[i];
            }

            int max = curSum;

            for (int i = k; i < nums.Length; i++)
            {
                curSum = curSum + nums[i] - nums[i - k];
                max = Math.Max(curSum, max);
            }

            return max * 1.0 / k;
        }

        /// <summary>
        /// https://leetcode.com/problems/pascals-triangle-ii/description/
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IList<int> GetRow(int rowIndex)
        {
            var ret = new int[rowIndex + 1];
            ret[0] = 1;
            for (int i = 1; i <= rowIndex; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (j == i) ret[j] = 1;
                    else
                    {
                        ret[j] = ret[j] + ret[j - 1];
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/two-sum/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i])) return new int[] { i, dict[target - nums[i]] };
                else
                {
                    if (!dict.ContainsKey(nums[i]))
                    {
                        dict.Add(nums[i], i);
                    }
                }
            }
            return new int[] { 0, 0 };
        }

        /// <summary>
        /// https://leetcode.com/problems/3sum/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var ret = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    var low = i + 1;
                    var high = nums.Length - 1;
                    while (low < high)
                    {
                        var sum = nums[i] + nums[low] + nums[high];
                        if (sum == 0)
                        {
                            ret.Add(new int[] { nums[i], nums[low], nums[high] });
                            while (low < high && nums[low] == nums[low + 1]) low++;
                            while (low < high && nums[high] == nums[high - 1]) high--;
                            low++;
                            high--;
                        }
                        else if (sum > 0)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/contains-duplicate-ii/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    if (i - dict[nums[i]] <= k) return true;
                    else dict[nums[i]] = i;
                }
                else
                {
                    dict.Add(nums[i], i);
                }
            }

            return false;
        }

        private static long getBucketId(long num, long size)
        {
            return num < 0 ? num / size - 1 : num / size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || k < 0 || t < 0) return false;

            int size = t + 1; //t might be 0, division by zero
            var dict = new Dictionary<long, long>();
            for (int i = 0; i < nums.Length; i++)
            {
                long id = getBucketId(nums[i], size);
                if (dict.ContainsKey(id)) return true;
                else if (dict.ContainsKey(id + 1) && Math.Abs(dict[id + 1] - nums[i]) <= t) return true;
                else if (dict.ContainsKey(id - 1) && Math.Abs(dict[id - 1] - nums[i]) <= t) return true;

                dict.Add(id, nums[i]);
                if (i >= k)
                {
                    dict.Remove(getBucketId(nums[i - k], size));
                }
            }

            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/merge-sorted-array/description/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
            }

            while (i >= 0)
            {
                nums1[k] = nums1[i];
                k--;
                i--;
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/trapping-rain-water/description/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int Trap1(int[] height)
        {
            var left = new int[height.Length];
            var right = new int[height.Length];

            int maxLeft = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] >= height[maxLeft])
                {
                    left[i] = -1;
                    maxLeft = i;
                }
                else
                {
                    left[i] = maxLeft;
                }
            }

            int maxRight = height.Length - 1;
            for (int i = maxRight; i >= 0; i--)
            {
                if (height[i] >= height[maxRight])
                {
                    right[i] = -1;
                    maxRight = i;
                }
                else
                {
                    right[i] = maxRight;
                }
            }

            var count = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (left[i] != -1 && right[i] != -1)
                {
                    if (left[i] < right[i])
                        count += (Math.Min(height[left[i]], height[right[i]]) - height[i]);
                }
            }

            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/shortest-unsorted-continuous-subarray/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindUnsortedSubarray(int[] nums)
        {
            var len = nums.Length;
            int start = -1, end = -2, max = nums[0], min = nums[len - 1];
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                min = Math.Min(min, nums[len - i - 1]);
                if (nums[i] < max) end = i;

                if (nums[len - i - 1] > min) start = len - i - 1;
            }

            return end - start + 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/search-a-2d-matrix/description/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0) return false;
            
            int colLen = matrix.GetUpperBound(1) + 1;

            int i = 0, j = matrix.Length;

            while(i < j)
            {
                int mid = (i + j) / 2;
                if (matrix[mid / colLen, mid % colLen] > target)
                {
                    j = mid - 1;
                }
                else if (matrix[mid / colLen, mid % colLen] < target)
                {
                    i = mid + 1;
                }
                else return true;
            }

            if (i / colLen > matrix.GetUpperBound(0) || i % colLen > matrix.GetUpperBound(1)) return false;

            return matrix[i / colLen, i % colLen] == target;
        }

        /// <summary>
        /// https://leetcode.com/problems/search-a-2d-matrix-ii/description/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix2(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0) return false;

            int col = matrix.GetUpperBound(1);
            int row = 0;

            while(row <= matrix.GetUpperBound(0) && col >= 0)
            {
                if (matrix[row, col] > target)
                {
                    col--;
                }
                else if (matrix[row, col] < target)
                {
                    row++;
                }
                else return true;
            }

            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/non-decreasing-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CheckPossibility(int[] nums)
        {
            int prev = nums[0];
            int countFail = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (prev <= nums[i])
                {
                    prev = nums[i];
                }
                else
                {
                    if (i >= 2 && nums[i - 2] > nums[i])
                    {
                        prev = nums[i - 1];
                    }
                    else
                    {
                        prev = nums[i];
                    }
                    countFail++;
                    if (countFail > 1) return false;
                }
            }

            return true;

        }

        /// <summary>
        /// https://leetcode.com/problems/maximum-length-of-repeated-subarray/description/
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int FindLength(int[] A, int[] B)
        {
            int max = 0;
            int[,] dp = new int[A.Length + 1, B.Length + 1];

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    if (i == 0 || j == 0) dp[i, j] = 0;
                    else
                    {
                        if(A[i -1]== B[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                            max = Math.Max(dp[i, j], max);
                        }
                        else
                        {
                            dp[i, j] = 0;
                        }
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-all-duplicates-in-an-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<int> FindDupplicates(int[] nums)
        {
            var ret = new List<int>();
            if (nums.Length == 0 || nums == null) return ret;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i]) - 1] < 0) ret.Add(Math.Abs(nums[i]));
                else
                {
                    nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
                }
            }

            return ret;

        }


        private static int ArrangementCount = 0;
        /// <summary>
        /// https://leetcode.com/problems/beautiful-arrangement/description/
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int CountArrangement(int N)
        {
            CountArrangementHelper(N, 1, new int[N + 1]);
            return ArrangementCount;
        }

        private static void CountArrangementHelper(int N, int cur, int[] used)
        {
            if(cur > N)
            {
                ArrangementCount++;
                return;
            }

            for (int i = 1; i <= N; i++)
            {
                 if(used[i] == 0 && (i % cur == 0 || cur % i == 0))
                {
                    used[i] = 1;
                    CountArrangementHelper(N, cur + 1, used);
                    used[i] = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SingleNumber(int[] nums)
        {
            int[] ret = new int[2];
            int mask = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                mask ^= nums[i];
            }
            mask &= -mask; //get last (right most 1), we can pick any 1 in mask

            for (int i = 0; i < nums.Length; i++)
            {
                if((nums[i] & mask) == 0)
                {
                    ret[0] ^= nums[i];
                }
                else
                {
                    ret[1] ^= nums[i];
                }
            }

            return ret;
        }
    }
}
