using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    public class Problems
    {
        /// <summary>
        /// https://leetcode.com/problems/number-of-islands/description/
        /// 11000
        /// 11000
        /// 00100
        /// 00011
        /// -> 3
        /// Shrink version
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int NumIslands(char[,] grid)
        {
            int count = 0;
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(1); j++)
                {
                    if(grid[i, j] == '1')
                    {
                        shrink(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        private static void shrink(char[,] grid, int i, int j)
        {
            if (i > grid.GetUpperBound(0) || j > grid.GetUpperBound(1) || i < 0 || j < 0 || grid[i, j] != '1') return;

            grid[i, j] = 'x';
            shrink(grid, i + 1, j);
            shrink(grid, i - 1, j);
            shrink(grid, i, j + 1);
            shrink(grid, i, j - 1);
        }

        /// <summary>
        /// https://leetcode.com/problems/all-paths-from-source-to-target/description/
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var result = new List<IList<int>>();
            Construct(graph, 0, new List<int>(), result);
            return result;
        }

        private static void Construct(int[][] graph, int row, IList<int> list, IList<IList<int>> res)
        {
            list.Add(row);
            if (row == graph.LongLength - 1)
            {
                res.Add(list);
                return;
            }
            for (int i = 0; i < graph[row].Length; i++)
            {
                Construct(graph, graph[row][i], new List<int>(list), res);
            }
        }
    }
}
