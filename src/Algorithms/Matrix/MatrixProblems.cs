using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Matrix
{
    public class MatrixProblems
    {
        /// <summary>
        /// Overlapping rectangles area
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="E"></param>
        /// <param name="F"></param>
        /// <param name="G"></param>
        /// <param name="H"></param>
        /// <returns></returns>
        public static long ComputeArea(long A, long B, long C, long D, long E, long F, long G, long H)
        {
            long overlap = -1;
            long width = Math.Min(C, G) - Math.Max(A, E);
            long height = Math.Min(D, H) - Math.Max(B, F);
            if (width <= 0 || height <= 0)
            {
                overlap = 0;
            }
            else
            {
                overlap = width * height;
            }

            return GetAreaOfRectangle(A, B, C, D) + GetAreaOfRectangle(E, F, G, H) - overlap;
        }

        private static long GetAreaOfRectangle(long A, long B, long C, long D)
        {
            return (Math.Abs(C - A)) * (Math.Abs(D - B));
        }

        public static int[][] rotateImage(int[][] a)
        {
            swapMatrix(a);
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a[i].Length; j++)
                {
                    var tmp = a[i][j];
                    a[i][j] = a[j][i];
                    a[j][i] = tmp;
                }
            }
            return a;
        }

        private static void swapMatrix(int[][] a)
        {
            int i = 0;
            while(i < a.Length / 2)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    int tmp = a[i][j];
                    a[i][j] = a[a.Length - 1 - i][j];
                    a[a.Length - 1 - i][j] = tmp;
                }
                i++;
            }
        }

        public static bool sudoku2(char[][] grid)
        {
            HashSet<string> hashSet = new HashSet<string>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != '.')
                    {
                        var rowStr = $"R{i}{grid[i][j]}";
                        var colStr = $"C{j}{grid[i][j]}";
                        var squareStr = $"S{i / 3 * 3 + j / 3}{grid[i][j]}";
                        if (hashSet.Contains(rowStr) || hashSet.Contains(colStr) || hashSet.Contains(squareStr)) return false;
                        hashSet.Add(rowStr);
                        hashSet.Add(colStr);
                        hashSet.Add(squareStr);
                    }   
                }
            }

            return true;
        }

    }
}
