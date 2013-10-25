using System;

class CombinationsGenerator
{
    static void Main()
    {
        int n = 3;
        int startNum = 4;
        int endNum = 8;

        int[] arr = new int[n];
        GenerateCombinations(arr, 0, startNum, endNum);
    }

    static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
    {
        if (index >= arr.Length)
        {
            // A combination was found --> print it
            Console.WriteLine("(" + String.Join(", ", arr) + ")");
        }
        else
        {
            for (int i = startNum; i <= endNum; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, index + 1, i + 1, endNum);
            }
        }
    }
}
