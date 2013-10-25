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

        Console.Write("S = ");
        int s = int.Parse(Console.ReadLine());

        int sum = 0;
        int bestStartIndex = 0;
        int bestLastIndex = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                sum = sum + arr[j];
                if (sum == s)
                {
                    bestStartIndex = i;
                    bestLastIndex = j;
                }
            }
            sum = 0;
        }

        if (bestStartIndex == 0 & bestLastIndex == 0)
        {
            Console.WriteLine("Doesn't exsist!");
        }
        else
        {
            for (int i = bestStartIndex; i <= bestLastIndex; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
    }
}