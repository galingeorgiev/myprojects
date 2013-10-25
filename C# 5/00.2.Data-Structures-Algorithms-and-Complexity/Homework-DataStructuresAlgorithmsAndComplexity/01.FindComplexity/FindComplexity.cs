/*What is the expected running time of the following C# code? Explain why. Assume the array's size is n.
*/

namespace FindComplexity
{
    using System;

    public class FindComplexity
    {
        // Task 1 code.
        public static long Compute(int[] arr)
        {
            long count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;

                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        {
                            start++;
                            count++;
                        }
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return count;
        }

        // Task 2 code.
        public static long CalcCount(int[,] matrix)
        {
            long count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, 0] % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        // Task 3 code.
        public static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;

            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                sum += matrix[row, col];
            }

            if (row + 1 < matrix.GetLength(1))
            {
                sum += CalcSum(matrix, row + 1);
            }
            
            return sum;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("---------- Task 1 ----------");
            Console.WriteLine("Runs in quadratic time O(n^2).");
            Console.WriteLine("The number of elementary steps is ~ n*n");

            Console.WriteLine("---------- Task 2 ----------");
            Console.WriteLine("Runs in quadratic time O(n*m).");
            Console.WriteLine("The number of elementary steps is ~ n-z + z*m");

            Console.WriteLine("---------- Task 3 ----------");
            Console.WriteLine("Runs in quadratic time O(n*m).");
            Console.WriteLine("The number of elementary steps is ~ n*m");
        }
    }
}