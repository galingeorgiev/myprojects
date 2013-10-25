using System;
using System.Diagnostics;

/* Add assertions in the code from the project "Assertions-Homework" to
 * ensure all possible preconditions and postconditions are checked. */

private class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Input array is empty.");
        Debug.Assert(arr.Length != 1, "Input array containe only one element.");
        Debug.Assert(arr != null, "Input array is null.");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Debug.Assert(minElementIndex > 0 || minElementIndex < arr.Length, "Elemennt is out of baundary of array.", "Please check minElementIndex.");
            Swap(ref arr[index], ref arr[minElementIndex]);

            // This condition must be checked in Swap method, but I must change original code and add 'where T : IComparable<T>'.
            Debug.Assert(arr[index].CompareTo(arr[minElementIndex]) <= 0, "Incorect behavior.", "Element arr[index] must be greater or equal to arr[minElementIndex]");
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Input array is empty.");
        Debug.Assert(arr.Length != 1, "Input array containe only one element.");
        Debug.Assert(arr != null, "Input array is null.");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }
  
    // I check input in public method and here this is useless.
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                // Index of searhed value.
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half.
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the left half.
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found.
        return -1;
    }

    private static void Main()
    {
        int[] arr = new int[] { 3, 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
