using Hands_On_2;
using System;
using System.ComponentModel.Design;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the array length:");
        int n;

        n =Convert.ToInt32( Console.ReadLine());
        int [] arr1=new int[n];
        for (int i = 0; i < arr1.Length; i++)
        {
            Console.WriteLine($"Enter {i} element", i);//String Interpolation
            arr1[i] = Convert.ToInt32( Console.ReadLine());
        }
        Console.WriteLine("Select a value \n 1.Insertion Sort\n 2.Selection Sort\n 3.Bubble Sort");
        int k=Convert.ToInt32(Console.ReadLine());
        if (k == 1)
        {
            InsertionSort isort = new InsertionSort(arr1);

        }
        else if (k == 2)
        {
            SelectionSort ssort = new SelectionSort(arr1);
        }
        else if (k == 3)
        {
            BubbleSort bubbleSort = new BubbleSort(arr1);

        }           
    }
}