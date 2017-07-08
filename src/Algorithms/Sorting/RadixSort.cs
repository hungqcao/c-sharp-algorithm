using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class RadixSort
    {
        // A utility function to get maximum value in arr[]
        public static int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        // A function to do counting sort of arr[] according to
        // the digit represented by exp.
        public static void countSort(int[] arr, int n, int exp, int radix)
        {
            int[] output = new int[n]; // output array
            int i;
            int[] count = new int[radix];

            // Store count of occurrences in count[]
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % radix]++;

            // Change count[i] so that count[i] now contains
            // actual position of this digit in output[]
            for (i = 1; i < radix; i++)
                count[i] += count[i - 1];

            // Build the output array
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % radix] - 1] = arr[i];
                count[(arr[i] / exp) % radix]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to curent digit
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }

        // The main function to that sorts arr[] of size n using
        // Radix Sort
        public static void radixsort(int[] arr, int n, int radix)
        {
            // Find the maximum number to know number of digits
            int m = getMax(arr, n);

            // Do counting sort for every digit. Note that instead
            // of passing digit number, exp is passed. exp is 10^i
            // where i is current digit number
            for (int exp = 1; m / exp > 0; exp *= radix)
                countSort(arr, n, exp, radix);
        }        
    }
}
