using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On_2
{
    public class InsertionSort
    {
        public InsertionSort(int[] arr1)
        {
            int n=arr1.Length;
            int key,j;
            for (int i = 0; i <n ; i++)
            {
                key=arr1[i];
                j=i-1;
                while(j>=0 && arr1[j]>key)
                {
                    arr1[j + 1] = arr1[j];
                    j=j-1;                   
                }
                arr1[j + 1] = key;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr1[i]);
            }
        }
    }
}
