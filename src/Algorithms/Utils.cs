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

        public static string SwapCharacters(string value, int position1, int position2)
        {
            //
            // Swaps characters in a string.
            //
            char[] array = value.ToCharArray(); // Get characters
            char temp = array[position1]; // Get temporary copy of character
            array[position1] = array[position2]; // Assign element
            array[position2] = temp; // Assign element
            return new string(array); // Return string
        }

        public static char[] SwapCharacters2(char[] value, int position1, int position2)
        {
            char temp = value[position1]; // Get temporary copy of character
            value[position1] = value[position2]; // Assign element
            value[position2] = temp; // Assign element
            return value; // Return string
        }
    }
}
