using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On_2
{
    public class BubbleSort
    {
        public BubbleSort(int[] arr1)
        {
            int n = arr1.Length;
            bool swapped; // Optimization: to check if any swaps occurred in a pass

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false; // Reset swapped flag for each pass

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr1[j] > arr1[j + 1])
                    {
                        // Swap arr[j] and arr[j+1]
                        int temp = arr1[j];
                        arr1[j] = arr1[j + 1];
                        arr1[j + 1] = temp;
                        swapped = true; // Set swapped flag to true
                    }
                }
            }
        }
    }
}
