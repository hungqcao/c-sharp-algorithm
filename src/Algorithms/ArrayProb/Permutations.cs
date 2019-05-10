using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayProb
{
    public class Permutations
    {
        public static IList<IList<int>> GetAllPermutations(IList<int> array)
        {
            var result = new List<IList<int>>();
            void Permutate(IList<int> currentArray, int startIndex)
            {
                for (int i = startIndex; i < array.Count; i++)
                {
                    var tmpArray = new List<int>(currentArray);
                    tmpArray.Add(array[i]);
                    result.Add(tmpArray);
                    Permutate(tmpArray, i + 1);
                }
            }

            Permutate(new List<int>(), 0);
            return result;
        }
    }
}
