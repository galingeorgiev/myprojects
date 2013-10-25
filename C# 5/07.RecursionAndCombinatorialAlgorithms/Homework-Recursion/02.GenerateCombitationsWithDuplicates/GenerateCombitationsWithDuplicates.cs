/* Write a recursive program for generating and printing all 
 * the combinations with duplicates of k elements from n-element set. 
 * Example:
 * n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
 */

namespace GenerateCombitationsWithDuplicates
{
    using System;

    public class GenerateCombitationsWithDuplicates
    {
        private static int[] currentLine;

        public static void GenerateCombinationsFrom1toN(int size, int startElement, int elementSet, int[] currentValue)
        {
            if (size == currentLine.Length)
            {
                Console.WriteLine(string.Join(" ", currentLine));
                return;
            }
            else
            {
                for (int i = startElement; i <= elementSet; i++)
                {
                    currentLine[size] = i;
                    GenerateCombinationsFrom1toN(size + 1, i, elementSet, currentLine);
                }
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value for k: ");
            int k = int.Parse(Console.ReadLine());
            currentLine = new int[k];
            GenerateCombinationsFrom1toN(0, 1, n, currentLine);
        }
    }
}
