/* Write a recursive program for generating and printing all 
* permutations of the numbers 1, 2, ..., n for given integer 
* number n. 
* Example:
* n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}
*/

namespace GeneratePermutations
{
    using System;

    public class GeneratePermutations
    {
        public static void PermutationsGenerator(int startFrom, int lenght, int[] currentPermutation)
        {
            /* when startFrom > lenght we are done and should print */
            if (startFrom <= lenght)
            {
                for (int i = startFrom; i <= lenght; i++)
                {
                    int tmp = currentPermutation[i];
                    for (int j = i; j > startFrom; j--)
                    {
                        currentPermutation[j] = currentPermutation[j - 1];
                    }

                    currentPermutation[startFrom] = tmp;

                    /* recurse on startFrom + 1 to lenght */
                    PermutationsGenerator(startFrom + 1, lenght, currentPermutation);
                    for (int j = startFrom; j < i; j++)
                    {
                        currentPermutation[j] = currentPermutation[j + 1];
                    }

                    currentPermutation[i] = tmp;
                }
            }
            else
            {
                for (int i = 1; i <= lenght; i++)
                {
                    Console.Write("{0} ", currentPermutation[i]);
                }

                Console.WriteLine();
            }
        }

        public static void Main()
        {
            Console.Write("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            int[] currentPermutation = new int[n + 1];

            /* create a workspace of numbers in their respective places */
            for (int i = 1; i <= n; i++)
            {
                currentPermutation[i] = i;
            }

            Console.WriteLine("Permutations:");
            PermutationsGenerator(1, n, currentPermutation);
        }
    }
}