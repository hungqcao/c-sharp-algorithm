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
        /// Reverse words order.
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

        /// <summary>
        /// Given a List of words, return the words that can be typed using letters of alphabet on only one row's of American keyboard like the image below.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string[] FindWords(string[] words)
        {
            var row1s = "qwertyuiop".ToDictionary(_ => _);
            var row2s = "asdfghjkl".ToDictionary(_ => _);
            var row3s = "zxcvbnm".ToDictionary(_ => _);
            var result = new List<string>();
            Func<string, Dictionary<char, char>, bool> isValid = (characters, source) =>
            {
                var uniqueChars = new String(characters.Distinct().ToArray());
                var res = true;
                foreach (var c in uniqueChars)
                {
                    if (!source.ContainsKey(Char.ToLower(c)))
                    {
                        res = false;
                        break;
                    }
                }

                return res;
            };

            foreach (var w in words)
            {
                if (isValid(w, row1s))
                {
                    result.Add(w);
                    continue;
                }
                if (isValid(w, row2s))
                {
                    result.Add(w);
                    continue;
                }
                if (isValid(w, row3s))
                {
                    result.Add(w);
                    continue;
                }
            }
            return result.ToArray();
        }

        public static string[] FindWordsV2(string[] words)
        {
            char[][] keyboard = {
                new char[] {'q', 'w', 'e', 'r', 't', 'y', 'i', 'u', 'o', 'p', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'},
                new char[] {'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'},
                new char[] {'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Z', 'X', 'C', 'V', 'B', 'N', 'M'}
            };
            IList<string> result = new List<string>();

            foreach (var word in words)
            {
                foreach (var row in keyboard)
                {
                    if (!row.Contains(word[0])) continue;

                    var forget = false;

                    for (var i = 1; i < word.Length; i++)
                    {
                        if (row.Contains(word[i])) continue;

                        forget = true;
                        break;
                    }

                    if (forget) break;

                    result.Add(word);
                    break;
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
        ///        Example 1:
        ///Input: "Let's take LeetCode contest"
        ///Output: "s'teL ekat edoCteeL tsetnoc"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var ret = new StringBuilder();
            var word = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    word.Append(s[i]);
                }
                else
                {
                    if (word.Length > 0)
                    {
                        //end of word
                        ret.Append(new String(word.ToString().Reverse().ToArray()));
                        word = new StringBuilder();
                    }
                    ret.Append(s[i]);
                }
            }

            //last word
            ret.Append(new String(word.ToString().Reverse().ToArray()));

            return ret.ToString();
        }

        /// <summary>
        /// https://leetcode.com/problems/ransom-note/#/description
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (dict.ContainsKey(magazine[i]))
                {
                    dict[magazine[i]]++;
                }
                else
                {
                    dict.Add(magazine[i], 1);
                }
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (dict.ContainsKey(ransomNote[i]))
                {
                    dict[ransomNote[i]]--;
                    if (dict[ransomNote[i]] < 0) return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
