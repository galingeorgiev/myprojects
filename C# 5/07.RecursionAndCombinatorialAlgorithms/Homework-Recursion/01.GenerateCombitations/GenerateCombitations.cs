/* Write a recursive program that simulates the
 * execution of n nested loops from 1 to n. 
 * Examples:
 *                            1 1 1
 *                            1 1 2
 *                            1 1 3
 *          1 1               1 2 1
 * n=2  ->  1 2      n=3  ->  ...
 *          2 1               3 2 3
 *          2 2               3 3 1
 *                            3 3 2
 *                            3 3 3
 */

namespace GenerateCombitations
{
    using System;

    public class Program
    {
        private static int[] currentLine;

        public static void GenerateCombinationsFrom1toN(int size, int[] currentValue)
        {
            if (size == currentLine.Length)
            {
                Console.WriteLine(string.Join(" ", currentLine));
                return;
            }
            else
            {
                for (int i = 1; i <= currentLine.Length; i++)
                {
                    currentLine[size] = i;
                    GenerateCombinationsFrom1toN(size + 1, currentLine);
                }
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            currentLine = new int[n];
            GenerateCombinationsFrom1toN(0, currentLine);
        }
    }
}
