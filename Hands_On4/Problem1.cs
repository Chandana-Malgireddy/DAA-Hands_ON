using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On4
{
    public class Problem1
    {
        public Problem1()
        {
            int[][] arr = new int[][]
        {
            new int[] { 1, 3, 5, 7 },
            new int[] { 2, 4, 6, 8 },
            new int[] { 0, 9, 10, 11 }
        };
            int K = 3, N = 4;
            List<int> mergedArray = MergeSortedArrays(arr, K, N);
            Console.WriteLine(string.Join(", ", mergedArray));

        }
        static List<int> MergeSortedArrays(int[][] arr, int K, int N)
        {
            List<int> result = new List<int>();
            int[] counters = new int[K]; // Keeps track of current index in each array

            while (MinValue(counters) < N)
            {
                int minValue = int.MaxValue;
                int minIdx = -1;

                for (int i = 0; i < K; i++)
                {
                    if (counters[i] >= N) continue;

                    if (arr[i][counters[i]] <= minValue)
                    {
                        minValue = arr[i][counters[i]];
                        minIdx = i;
                    }
                }

                result.Add(minValue);
                counters[minIdx]++;
            }

            return result;
        }

        // Helper function to get the minimum value from the counters array
        static int MinValue(int[] counters)
        {
            int min = int.MaxValue;
            foreach (int val in counters)
            {
                if (val < min)
                    min = val;
            }
            return min;
        }


    }
}
