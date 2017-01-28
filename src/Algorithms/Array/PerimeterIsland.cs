using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Array
{
    /// <summary>
    /// 
    ///var calPerimeter = new PerimeterIsland();
    ///var a = calPerimeter.IslandPerimeter(new int[,]
    ///{
    ///            { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 }
    ///});
    /// </summary>
    public class PerimeterIsland
    {
        public int IslandPerimeter(int[,] grid)
        {
            var res = 0;
            for (int rowIndx = 0; rowIndx < grid.GetLength(0); rowIndx++)
            {
                for (int colIndx = 0; colIndx < grid.GetLength(1); colIndx++)
                {
                    res += BlockPerimeter(grid, rowIndx, colIndx);
                }
            }

            return res;
        }

        public int BlockPerimeter(int[,] grid, int rowIndex, int colIndex)
        {
            int res = 0;
            if (grid[rowIndex, colIndex] == 0) return res;
            //look at left
            if(IsValidIndex(grid, rowIndex, colIndex - 1))
            {
                if(grid[rowIndex, colIndex - 1] == 0)
                {
                    res++;
                }
            }
            else
            {
                res++;
            }
            //look at right
            if (IsValidIndex(grid, rowIndex, colIndex + 1))
            {
                if (grid[rowIndex, colIndex + 1] == 0)
                {
                    res++;
                }
            }
            else
            {
                res++;
            }
            //look at top
            if (IsValidIndex(grid, rowIndex - 1, colIndex))
            {
                if (grid[rowIndex - 1, colIndex] == 0)
                {
                    res++;
                }
            }
            else
            {
                res++;
            }
            //look at bottom
            if (IsValidIndex(grid, rowIndex + 1, colIndex))
            {
                if (grid[rowIndex + 1, colIndex] == 0)
                {
                    res++;
                }
            }
            else
            {
                res++;
            }

            return res;
        }

        public bool IsValidIndex(int[,] grid, int rowIndex, int colIndex)
        {
            var res = true;
            if (!(0 <= rowIndex && grid.GetLength(0) > rowIndex))
                res = false;
            if (!(0 <= colIndex && grid.GetLength(1) > colIndex))
                res = false;
            return res;
        }
    }
}
