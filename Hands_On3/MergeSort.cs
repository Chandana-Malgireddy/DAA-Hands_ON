using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On3
{
    public class MergeSort
    {
        public void MergeSort1(int[] arr)
        {
            if (arr.Length > 1)
            {

                int mid = arr.Length / 2;
                int[] leftHalf = new int[mid];
                int[] rightHalf = new int[arr.Length - mid];

                Array.Copy(arr, 0, leftHalf, 0, mid);
                Array.Copy(arr, mid, rightHalf, 0, arr.Length - mid);

                MergeSort1(leftHalf);
                MergeSort1(rightHalf);
                Merge(arr, leftHalf, rightHalf);
            }
        }

        // Merge two halves
        public static void Merge(int[] arr, int[] leftHalf, int[] rightHalf)
        {
            int i = 0, j = 0, k = 0;

            while (i < leftHalf.Length && j < rightHalf.Length)
            {
                if (leftHalf[i] < rightHalf[j])
                {
                    arr[k] = leftHalf[i];
                    i++;
                }
                else
                {
                    arr[k] = rightHalf[j];
                    j++;
                }
                k++;
            }
            while (i < leftHalf.Length)
            {
                arr[k] = leftHalf[i];
                i++;
                k++;
            }

            while (j < rightHalf.Length)
            {
                arr[k] = rightHalf[j];
                j++;
                k++;
            }
        }
        public void PrintArray(int[] arr)
        {
            Console.WriteLine("After Sorted:");
            foreach (int val in arr)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }
}
