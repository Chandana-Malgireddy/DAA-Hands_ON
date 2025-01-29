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
            bool swapped; 
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr1[j] > arr1[j + 1])
                    {
                        int temp = arr1[j];
                        arr1[j] = arr1[j + 1];
                        arr1[j + 1] = temp;
                        swapped = true; 
                    }
                }
            }
            //Console.WriteLine("After Swapping:");
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(arr1[i]);
            //}

        }
    }
}
