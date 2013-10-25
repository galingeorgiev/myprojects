/* Write a program for generating and printing all 
 * subsets of k strings from given set of strings.
 * Example: s = {test, rock, fun}, k=2
 * (test rock),  (test fun),  (rock fun)
 */

namespace GenerateAllSubsets
{
    using System;

    public class GenerateAllSubsets
    {
        private static string[] currentLine;
        private static string[] setOfElements;

        public static void GenerateCombinationsFrom1ToN(int size, int startElement, int elementSet, string[] currentValue)
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
                    currentLine[size] = setOfElements[i];
                    GenerateCombinationsFrom1ToN(size + 1, i + 1, elementSet, currentLine);
                }
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            currentLine = new string[n];

            Console.WriteLine("Enter number of elements in set: ");
            int k = int.Parse(Console.ReadLine());
            setOfElements = new string[k];

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("Enter element of set on position {0} of {1}", i, n);
                setOfElements[i] = Console.ReadLine();
            }

            GenerateCombinationsFrom1ToN(0, 0, n, currentLine);
        }
    }
}
