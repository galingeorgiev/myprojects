/* Modify the previous program to skip duplicates:
 * n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
 */

namespace GenerateCombitationsWithoutDuplicates
{
    using System;

    public class GenerateCombitationsWithoutDuplicates
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
                    GenerateCombinationsFrom1toN(size + 1, i + 1, elementSet, currentLine);
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
