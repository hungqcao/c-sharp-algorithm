using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DivideAndConquer
{
    public class DivideAndConquer
    {
        /// <summary>
        /// https://leetcode.com/problems/different-ways-to-add-parentheses/description/
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IList<int> DiffWaysToCompute(string input)
        {
            var list = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*')
                {
                    var part1 = DiffWaysToCompute(input.Substring(0, i));
                    var part2 = DiffWaysToCompute(input.Substring(i + 1));

                    foreach (var p1 in part1)
                    {
                        foreach (var p2 in part2)
                        {
                            switch (input[i])
                            {
                                case '+':
                                    list.Add(p1 + p2);
                                    break;
                                case '-':
                                    list.Add(p1 - p2);
                                    break;
                                case '*':
                                    list.Add(p1 * p2);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            if(list.Count == 0)
            {
                list.Add(int.Parse(input));
            }

            return list;
        }
    }
}
