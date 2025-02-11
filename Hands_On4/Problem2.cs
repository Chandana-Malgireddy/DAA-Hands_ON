using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On4
{
    public class Problem2
    {
        public Problem2()
        {
            int[] arr1 = new int[] {2,2,2,2,2};
            int[] arr2= new int[] {1, 2, 2, 3, 4, 4, 4, 5, 5 };
            Delduplicate(arr1);
            Delduplicate(arr2);

        }
        public static void Delduplicate(int[] arr)
        {
            int j = 0,i=0;
            List<int> list = new List<int>();
            if (arr.Length > 0)
            {
                list.Add(arr[0]);
            }
            for (i = 1; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 1]) 
                {
                    list.Add(arr[i]);
                }
            }
            for (i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }

    }
}
