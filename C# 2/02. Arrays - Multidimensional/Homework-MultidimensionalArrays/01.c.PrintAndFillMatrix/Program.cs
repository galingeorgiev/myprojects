using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int counter = 1;

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 0; j < n - i; j++)
            {
                matrix[i + j, j] = counter;
                counter++;
            }
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                matrix[j, j + i] = counter;
                counter++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}",matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}