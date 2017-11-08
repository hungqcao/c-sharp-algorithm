using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Strings
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

        /// <summary>
        /// https://leetcode.com/problems/detect-capital/#/description
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool DetectCapitalUse(string word)
        {
            if (word.Length <= 1) return true;

            int firstSeenCap = Char.IsUpper(word[0]) ? 0 : -1;
            bool allCap = false;
            bool allLow = false;
            for (int i = 1; i < word.Length; i++)
            {
                if (Char.IsUpper(word[i]))
                {
                    if (allLow) return false;
                    allCap = true;
                    allLow = false;
                }
                else
                {
                    if (allCap) return false;
                    allLow = true;
                    allCap = false;
                }
            }
            if (allCap && firstSeenCap == 0) return true;
            if (allLow) return true;
            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/excel-sheet-column-number/#/description
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int TitleToNumber(string s)
        {
            int ret = 0;
            int times = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                ret += (s[i] - 'A' + 1) * (int)Math.Pow(26, times);
                times++;
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/relative-ranks/#/description
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static string[] FindRelativeRanks(int[] nums)
        {
            var ordered = nums.OrderByDescending(_ => _).ToList();
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < ordered.Count(); i++)
            {
                dict.Add(ordered[i], i);
            }

            return nums.Select((n, i) =>
            {
                var index = dict[n];
                var ret = "";
                if (index == 0) ret = "Gold medal";
                else if (index == 1) ret = "Silver medal";
                else if (index == 2) ret = "Bronze medal";
                else ret = (index + 1).ToString();

                return ret;
            }).ToArray();
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-palindrome/#/description
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestPalindrome(string s)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }

            int ret = 0;
            bool metOdd = false;
            foreach (var item in dict)
            {
                if (item.Value % 2 == 0) ret += item.Value;
                else
                {
                    ret += (item.Value / 2) * 2;
                    if (!metOdd) { ret += item.Value % 2; metOdd = true; }
                }
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/judge-route-circle/description/
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public static bool JudgeCircle(string moves)
        {
            var dict = new Dictionary<char, int>();
            dict.AddOrSet('U', 0);
            dict.AddOrSet('D', 0);
            dict.AddOrSet('L', 0);
            dict.AddOrSet('R', 0);
            for (int i = 0; i < moves.Length; i++)
            {
                dict.AddOrSet(moves[i], (cur) => ++cur);
            }

            return (dict['U'] == dict['D']) && (dict['L'] == dict['R']);
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-vowels-of-a-string/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseVowels(string s)
        {
            if (s == null || s.Length == 0) return s;
            string vowels = "aeiouAEIOU";
            char[] chars = vowels.ToCharArray();
            int start = 0;
            int end = s.Length - 1;
            char[] ret = s.ToCharArray();
            while (start < end)
            {
                while (start < s.Length)
                {
                    if (chars.Contains(s[start])) break;
                    start++;
                }

                while (end > 0)
                {
                    if (chars.Contains(s[end])) break;
                    end--;
                }

                if (start < end)
                {
                    ret = Utils.SwapCharacters2(ret, start, end);
                }
                start++;
                end--;
            }

            return new string(ret);
        }

        /// <summary>
        /// https://leetcode.com/problems/repeated-substring-pattern/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool RepeatedSubstringPattern(string s)
        {
            for (int i = 1; i <= s.Length / 2; i++)
            {
                if (s.Length % i == 0)
                {
                    var tmp = s.Substring(0, i);
                    var builder = new StringBuilder();
                    for (int j = 0; j < s.Length / i; j++)
                    {
                        builder.Append(tmp);
                    }
                    if (builder.ToString().Equals(s))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/isomorphic-strings/description/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsIsomorphic(string s, string t)
        {
            if (s == null || t == null || s.Length != t.Length) return false;
            var d1 = new int[256];
            var d2 = new int[256];
            for (int i = 0; i < s.Length; i++)
            {
                if (d1[s[i]] != d2[t[i]]) return false;
                d1[s[i]] = i + 1;
                d2[t[i]] = i + 1;
            }

            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
        /// cbaebabacd
        /// abc
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IList<int> FindAnagrams(string s, string p)
        {
            var ret = new List<int>();
            var stillNeed = new Dictionary<char, int>(); //Meaning if you want to establish an anagram of string p, you still need how many characters
            foreach (var c in p)
            {
                stillNeed.AddOrSet(c, stillNeed.GetValueOrDefault(c, 0) + 1);
            }

            int counter = stillNeed.Count; // number of unique characters in p

            //start at the beginning
            int start = 0, end = 0;

            while (end < s.Length)
            {
                var endChar = s[end];
                if (stillNeed.ContainsKey(endChar))
                {
                    stillNeed[endChar]--;
                    if (stillNeed[endChar] == 0) counter--;
                }
                end++;
                while (counter == 0)
                {
                    var startChar = s[start];
                    if (stillNeed.ContainsKey(s[start]))
                    {
                        stillNeed.AddOrSet(startChar, stillNeed.GetValueOrDefault(startChar, 0) + 1);
                        if (stillNeed[startChar] > 0) counter++;
                    }
                    if (end - start == p.Length)
                    {
                        ret.Add(start);
                    }
                    start++;
                }
            }

            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/valid-palindrome-ii/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidPalindrome(string s)
        {
            if (s == null) return false;

            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return IsPalindrome(s, i + 1, j) || IsPalindrome(s, i, j - 1);
                }
                i++;
                j--;
            }

            return true;
        }

        private static bool IsPalindrome(string s, int start, int end)
        {
            while (start <= end)
            {
                if (s[start] != s[end]) return false;
                start++;
                end--;
            }

            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-common-prefix/description/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            string pre = strs[0];
            for (int i = 0; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(pre) != 0)
                {
                    pre = pre.Substring(0, pre.Length - 1);
                }
            }

            return pre;
        }

        /// <summary>
        /// https://leetcode.com/problems/multiply-strings/discuss/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static string Multiply(string num1, string num2)
        {
            int[] ret = new int[num1.Length + num2.Length];
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int multiply = (num1[i] - '0') * (num2[j] - '0');
                    int p1 = i + j, p2 = i + j + 1;
                    int sum = multiply + ret[p2];

                    ret[p1] += sum / 10;
                    ret[p2] = sum % 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int p in ret) if (!(sb.Length == 0 && p == 0)) sb.Append(p);
            return sb.Length == 0 ? "0" : sb.ToString();
        }

        private static int low = -1;
        private static int max = 0;
        /// <summary>
        /// https://leetcode.com/problems/longest-palindromic-substring/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindromeSubstring(string s)
        {
            low = -1;
            max = 0;
            if (s == null) return string.Empty;
            int len = s.Length;
            if (len < 2) return s;

            for (int i = 0; i < s.Length; i++)
            {
                IsLongestPalindromeHelper(s, i, i);
                IsLongestPalindromeHelper(s, i, i + 1);
            }

            return s.Substring(low, max);
        }

        /// <summary>
        /// Is plaindrome started from i, j
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void IsLongestPalindromeHelper(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--;
                j++;
            }

            if (max < j - i - 1)
            {
                max = j - i - 1;
                low = i + 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ConvertToTitle(int n)
        {
            return n == 0 ? "" : ConvertToTitle(--n / 26) + (char)('A' + (n % 26));
        }

        /// <summary>
        /// https://leetcode.com/problems/palindromic-substrings/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CountSubstrings(string s)
        {
            int ret = 0;
            if (string.IsNullOrWhiteSpace(s)) return ret;
            for (int i = 0; i < s.Length; i++)
            {
                ret += CountHelper(s, i, i) + CountHelper(s, i, i + 1);
            }

            return ret;
        }

        private static int CountHelper(string s, int l, int r)
        {
            int count = 0;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                count++;
                l--;
                r++;
            }

            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/arithmetic-slices/discuss/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int NumberOfArithmeticSlices(int[] A)
        {
            int cur = 0;
            int sum = 0;
            for (int i = 2; i < A.Length; i++)
            {
                if (A[i - 1] - A[i - 2] == A[i] - A[i - 1])
                {
                    cur++;
                    sum += cur;
                }
                else
                {
                    cur = 0;
                }
            }

            return sum;
        }

        /// <summary>
        /// https://leetcode.com/problems/sort-characters-by-frequency/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FrequencySort(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in s)
            {
                dict.AddOrSet(c, dict.GetValueOrDefault(c, 0) + 1);
            }

            var buckets = new IList<char>[s.Length + 1];
            foreach (var item in dict)
            {
                if (buckets[item.Value] == null)
                {
                    buckets[item.Value] = new List<char>();

                }
                buckets[item.Value].Add(item.Key);
            }

            var ret = new StringBuilder();
            for (int i = buckets.Length - 1; i >= 0; i--)
            {
                if (buckets[i] != null)
                {
                    foreach (var item in buckets[i])
                    {
                        for (int j = 0; j < i; j++)
                        {
                            ret.Append(item);
                        }
                    }
                }
            }

            return ret.ToString();
        }

        /// <summary>
        /// https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/discuss/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int MinimumDeleteSum(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 1; i <= s2.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] + s2[i - 1];
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
                for (int j = 1; j <= s2.Length; j++)
                {
                    if(s1[i - 1] == s2[j - 1])
                    {
                        //no deletetion
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i, j - 1] + s2[j - 1], dp[i - 1, j] + s1[i - 1]);
                    }
                }
            }

            return dp[s1.Length, s2.Length];
        }

        /// <summary>
        /// https://leetcode.com/problems/delete-operation-for-two-strings/description/
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public static int MinDistance(string word1, string word2)
        {
            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 1; i <= word2.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] + 1;
            }

            for (int i = 1; i <= word1.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + 1;
                for (int j = 1; j <= word2.Length; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1);
                    }
                }
            }

            return dp[word1.Length, word2.Length];
        }        
    }
}
