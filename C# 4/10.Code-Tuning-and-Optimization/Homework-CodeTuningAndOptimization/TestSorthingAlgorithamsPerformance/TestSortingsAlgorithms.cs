using System;
using System.Diagnostics;

/* *Write a program to compare the performance of insertion sort, selection sort, quicksort for int,
 * double and string values. Check also the following cases: random values, sorted values, values sorted in reversed order. */

namespace TestSorthingAlgorithmsPerformance
{
    public class Program
    {
        public static void Main()
        {
            // Test sorting array of ints
            int[] testIntArr = SortingMethods.GenerateIntArr();
            SortingMethods.InsertionSort(testIntArr);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            testIntArr = SortingMethods.GenerateIntArr();
            SortingMethods.QuickSort(testIntArr, 0, testIntArr.Length - 1);
            sw.Stop();
            long algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();
            Console.WriteLine(
                "Quick sort algorithm with integers needed {0} milliseconds.",
                algorithmNeededTime);

            testIntArr = SortingMethods.GenerateIntArr();
            SortingMethods.SelectionSort(testIntArr);
            Console.WriteLine();

            // Test sorting array of double
            double[] testDoubleArr = SortingMethods.GenerateDoubleArr();
            SortingMethods.InsertionSort(testDoubleArr);

            sw.Start();
            testDoubleArr = SortingMethods.GenerateDoubleArr();
            SortingMethods.QuickSort(testDoubleArr, 0, testDoubleArr.Length - 1);
            sw.Stop();
            algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();
            Console.WriteLine(
                "Quick sort algorithm with double needed {0} milliseconds.",
                algorithmNeededTime);

            testDoubleArr = SortingMethods.GenerateDoubleArr();
            SortingMethods.SelectionSort(testDoubleArr);
            Console.WriteLine();

            // Test sorting array of strings
            string[] testStringArr = SortingMethods.GenerateStringArr();
            SortingMethods.InsertionSort(testStringArr);

            sw.Start();
            testStringArr = SortingMethods.GenerateStringArr();
            SortingMethods.QuickSort(testStringArr, 0, testStringArr.Length - 1);
            sw.Stop();
            algorithmNeededTime = sw.ElapsedMilliseconds;
            sw.Reset();
            Console.WriteLine(
                "Quick sort algorithm with strings needed {0} milliseconds.",
                algorithmNeededTime);

            testStringArr = SortingMethods.GenerateStringArr();
            SortingMethods.SelectionSort(testStringArr);
            Console.WriteLine();

            Console.WriteLine("My experiment show that Quick sort is the fastest algorithm.");
        }
    }
}
