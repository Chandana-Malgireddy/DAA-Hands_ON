using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On_2
{
    public class SelectionSort
    {
        public SelectionSort(int[] arr1)
        {
            int n=arr1.Length;
            
            for (int i = 0; i < n; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr1[j] < arr1[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr1[minIndex];
                arr1[minIndex] = arr1[i];
                arr1[i] = temp;
            }

        }
    }
}
