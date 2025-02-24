using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON6
{
    internal class RandomQuickSort
    {
        private static Random rand = new Random();

        public static void RandomQuicksort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = RandomPartition(arr, low, high);
                RandomQuicksort(arr, low, pivot - 1);  // Left part
                RandomQuicksort(arr, pivot + 1, high); // Right part
            }
        }

        private static int RandomPartition(int[] arr, int low, int high)
        {
            int randomIndex = rand.Next(low, high + 1);
            Swap(ref arr[randomIndex], ref arr[high]); // Swap random pivot to end
            return Partition(arr, low, high);
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // Pivot at the end
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
