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
    }
}
