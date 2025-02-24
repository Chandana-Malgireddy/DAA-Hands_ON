using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON6
{
    internal  class NonRandomQuickSort
    {
        public void NonRandomQuicksort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(arr, low, high);  // Get pivot index
                NonRandomQuicksort(arr, low, pivot - 1); // Left part
                NonRandomQuicksort(arr, pivot + 1, high); // Right part
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // Last element as pivot
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(ref arr[i], ref arr[j]);
                }
            }
            Swap(ref arr[i + 1], ref arr[high]);
            return i + 1;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
