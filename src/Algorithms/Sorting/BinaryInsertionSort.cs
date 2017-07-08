using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class BinaryInsertionSort
    {
        // Function to sort an array a[] of size 'n'
        public static void insertionSort(int[] a, int n)
        {
            int i, loc, j, k, selected;

            for (i = 1; i < n; ++i)
            {
                j = i - 1;
                selected = a[i];

                // find location where selected sould be inseretd
                loc = Search.BinarySearch.binarySearch(a, selected, 0, j);

                // Move all elements after location to create space
                while (j >= loc)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = selected;
            }
        }

        // Driver program to test above function
        public static int main()
        {
            int[] a = {37, 23, 0, 17, 12, 72, 31,
              46, 100, 88, 54};

            insertionSort(a, a.Length);            

            return 0;
        }
    }
}
