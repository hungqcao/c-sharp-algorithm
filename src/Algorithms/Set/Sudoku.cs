using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set
{
    public class Sudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            var hashSet = new HashSet<string>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if(board[i][j] != '.')
                    {
                        hashSet.Add($"C{j}-{board[i][j]}");
                        hashSet.Add($"R{i}-{board[i][j]}");
                        hashSet.Add($"B{board.GetLowerBound(0) % (i*3)}-{board[i][j]}");
                        Console.WriteLine($"C{j}-{board[i][j]}");
                        Console.WriteLine($"R{i}-{board[i][j]}");
                        Console.WriteLine($"B{board.GetLowerBound(0) % (i * 3)}-{board[i][j]}");
                    }
                }
            }
            return true;
        }       
    }
}
