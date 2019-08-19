using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.WordBreak
{
    public class WordBreakII
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return DFS(s, new Dictionary<string, IList<string>>(), wordDict);
        }

        public IList<string> DFS(string s, Dictionary<string, IList<string>> memo, IList<string> wordDict)
        {
            if (memo.ContainsKey(s))
            {
                return memo[s];
            }

            var result = new List<string>();
            if (s.Length == 0)
            {
                result.Add("");
                return result;
            }
            foreach (var word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    var list = DFS(s.Substring(word.Length), memo, wordDict);
                    foreach (var subWord in list)
                    {
                        result.Add(word + (string.IsNullOrEmpty(subWord) ? "" : " ") + subWord);
                    }
                }
            }

            memo.Add(s, result);
            return result;
        }

        public IList<string> WordBreak_TimeLimitExceed(string s, IList<string> wordDict)
        {
            var set = new HashSet<string>();
            foreach (var w in wordDict) set.Add(w);

            var result = new List<string>();
            GetSentence(s, 0, set, new StringBuilder(), new StringBuilder(), result);
            return null;
        }

        public void GetSentence(string s, int start, HashSet<string> set, StringBuilder curWord, StringBuilder curSen, IList<string> result)
        {
            if(start == s.Length)
            {
                result.Add(curSen.ToString().Trim());
            }
            int i = start;
            while (i < s.Length)
            {
                curWord.Append(s[i]);
                if (set.Contains(curWord.ToString()))
                {
                    var prevSen = new StringBuilder(curSen.ToString());
                    curSen.Append(curWord.ToString() + " ");
                    GetSentence(s, i + 1, set, new StringBuilder(), curSen, result);
                    //GetSentence(s, i + 1, set, new StringBuilder(curWord.ToString()), curWord, result);
                    curSen = new StringBuilder(prevSen.ToString());
                }
                i++;
            }
            Console.WriteLine(curSen);
        }
    }
}
