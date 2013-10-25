using System;

namespace MultidimensionalArray
{
    class Program
    {
        static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0)
                    {
                        counter++;
                        arr[j, i] = counter;
                    }
                    else
                    {
                        counter++;
                        arr[n - j - 1, i] = counter;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}