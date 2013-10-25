/* Write a method that finds the longest subsequence of equal 
 * numbers in given List<int> and returns the result as new 
 * List<int>. Write a program to test whether the method works 
 * correctly. 
 */

namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestSubsequenceOfEqualNumbers
    {
        public static List<int> LongestSubsequence(List<int> input)
        {
            int bestCount = 0;
            int bestValue = 0;

            if (input.Count == 0)
            {
                throw new ArgumentException("List is empty.");
            }

            var uniqueValuesInList = new HashSet<int>();
            foreach (var item in input)
            {
                if (!uniqueValuesInList.Contains(item))
                {
                    uniqueValuesInList.Add(item);
                }
            }

            foreach (var uniqueItem in uniqueValuesInList)
            {
                int count = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    while (uniqueItem == input[i])
                    {
                        count++;
                        i++;

                        if (i > input.Count - 1)
                        {
                            break;
                        }
                    }

                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestValue = uniqueItem;
                        count = 0;
                    }
                }
            }

            List<int> longestSubsequence = new List<int>();
            for (int i = 0; i < bestCount; i++)
            {
                longestSubsequence.Add(bestValue);
            }

            return longestSubsequence;
        }

        public static void Main()
        {
            List<int> input = new List<int>() { 1, 1, 1, 1, 1, 2, 3, 3, 3, 3, 2, 2, 3, 5, 5, 5, 5, 5 };
            List<int> result = LongestSubsequence(input);

            Console.WriteLine("Longest subsequence is: ");
            Console.WriteLine(string.Join(", ", result));
        }
    }
}