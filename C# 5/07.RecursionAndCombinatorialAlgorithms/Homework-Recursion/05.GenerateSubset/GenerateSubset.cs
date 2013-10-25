/* Write a recursive program for generating and printing all 
 * ordered k-element subsets from n-element set (variations Vkn).
 * Example: n=3, k=2, set = {hi, a, b} =>
 * (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
 */

namespace GenerateSubset
{
    using System;

    public class GenerateSubset
    {
        private static string[] currentLine;
        private static string[] setOfElements;

        public static void GenerateCombinationsFrom1toN(int size, string[] currentValue)
        {
            if (size == currentLine.Length)
            {
                Console.WriteLine(string.Join(" ", currentLine));
                return;
            }
            else
            {
                for (int i = 0; i < setOfElements.Length; i++)
                {
                    currentLine[size] = setOfElements[i];
                    GenerateCombinationsFrom1toN(size + 1, currentLine);
                }
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            setOfElements = new string[n];

            Console.WriteLine("Enter value for k: ");
            int k = int.Parse(Console.ReadLine());
            currentLine = new string[k];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter element of set on position {0} of {1}", i, n);
                setOfElements[i] = Console.ReadLine();
            }

            GenerateCombinationsFrom1toN(0, currentLine);
        }
    }
}
