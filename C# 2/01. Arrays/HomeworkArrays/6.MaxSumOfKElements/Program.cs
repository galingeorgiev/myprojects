using System;

class Program
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int counter = 0;
        int bestCount = 0;
        int firstIndex = 0;
        int sum = 0;

        for (int i = 0; i <= n - k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                sum = sum + arr[i + j];
            }
            if (sum > bestCount)
            {
                bestCount = sum;
                firstIndex = i;
            }
            sum = 0;
        }

        for (int i = firstIndex; i < firstIndex + k; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
    }
}