using System;

class Program
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("M = ");
        int m = int.Parse(Console.ReadLine());
        int sum = int.MinValue;
        int bestSum = 0;
        int bestStartIndexX = 0;
        int bestStartIndexY = 0;
        int[,] arr = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("{0} {1} = ", i, j);
                arr[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < n - 2; j++)
            {
                sum = arr[i, j] + arr[i, j + 1] + arr[i, j + 2] + arr[i + 1, j] + arr[i + 1, j + 1] + arr[i + 1, j + 2] + arr[i + 2, j] + arr[i + 2, j + 1] + arr[i + 2, j + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestStartIndexX = j;
                    bestStartIndexY = i;
                }
            }
        }

        Console.WriteLine("Best matrix 3X3 is: ");

        for (int i = bestStartIndexY; i < bestStartIndexY + 3; i++)
        {
            for (int z = bestStartIndexX; z < bestStartIndexX + 3; z++)
            {
                Console.Write("{0,4}", arr[i, z]);
            }
            Console.WriteLine();
        }
    }
}
