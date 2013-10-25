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

        int count = 1;
        int bestCount = 0;
        int bestValue = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (arr[i] == arr[j])
                {
                    count++;
                }
            }
            if (count > bestCount)
            {
                bestCount = count;
                bestValue = arr[i];
            }
            count = 1;
        }
        Console.WriteLine("Value {0} is repeated {1} times.", bestValue, bestCount);
    }
}
