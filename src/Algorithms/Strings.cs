using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Strings
    {
        /// <summary>
        /// Strings.removeDupplicatesInString("geeksforgeeks");
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string removeDupplicatesInString(string input)
        {
            bool[] check = new bool[256];
            var builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                var val = Convert.ToInt32(input[i]);
                if (!check[val])
                {
                    builder.Append(input[i]);
                    check[val] = true;
                }
            }
            return builder.ToString();
        }

        public static string reverse(string input, int start, int end)
        {
            char[] array = input.ToCharArray();
            while (start < end)
            {
                var temp = input[start];
                array[start] = input[end];
                array[end] = temp;
                start++;
                end--;
            }
            return new string(array);
        }

        /// <summary>
        /// Strings.reverseString("  i   like  this program   very much   ");
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string reverseString(string input)
        {
            var start = 0;
            var end = 0;
            while (end < input.Length)
            {
                while (start < input.Length && string.IsNullOrWhiteSpace(input[start].ToString()))
                {
                    start++;
                }
                end = start;
                while (end < input.Length && !string.IsNullOrWhiteSpace(input[end].ToString()))
                {
                    end++;
                }
                input = reverse(input, start, end - 1);
                start = end;
            }
            input = reverse(input, 0, input.Length - 1);
            return input;
        }

        public string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            StringBuilder builder = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                builder.Append(s[i]);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 
        /// Strings.FindTheDifference("abcd", "aebcd");
        /// Input:
        ///        s = "abcd"
        ///t = "abcde"
        ///Output:
        ///e
        ///Explanation:
        ///'e' is the letter that was added.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static char FindTheDifference(string s, string t)
        {
            char res = t[t.Length - 1];
            for (int i = 0; i < t.Length - 1; i++)
            {
                res ^= s[i];
                res ^= t[i];
            }
            return res;
        }
    }
}
