using System;

class Program
{
    static void Main()
    {
        Console.Write("Lenght of array is: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int sum = 0;
        int bestSum = 0;
        int bestFirstIndex = 0;

        for (int i = 0; i < n - 4; i++)
        {
            for (int j = i; j < i + 4; j++)
            {
                sum = sum + arr[j];
            }
            if (sum > bestSum)
            {
                bestSum = sum;
                bestFirstIndex = i;
            }
            sum = 0;
        }
        for (int i = bestFirstIndex; i < bestFirstIndex + 4; i++)
        {
            Console.Write(arr[i]);
            Console.Write(" ");
        }
        Console.WriteLine("Best sum is: {0}", bestSum);
    }
}