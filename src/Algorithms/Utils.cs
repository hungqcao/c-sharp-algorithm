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

        public static TValue GetValueOrDefault<TKey, TValue>
   (this IDictionary<TKey, TValue> dictionary,
    TKey key,
    TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static void AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        public static void AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TValue, TValue> calValue)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = calValue(dict[key]);
            }
            else
            {
                dict.Add(key, calValue(default(TValue)));
            }
        }
    }
}
