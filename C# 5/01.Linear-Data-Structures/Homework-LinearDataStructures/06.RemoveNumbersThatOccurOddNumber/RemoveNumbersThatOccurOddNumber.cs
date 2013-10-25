/* Write a program that removes from given sequence all 
 * numbers that occur odd number of times. Example:
 * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}
 */

namespace RemoveNumbersThatOccurOddNumber
{
    using System;
    using System.Collections.Generic;

    public class RemoveNumbersThatOccurOddNumber
    {
        public static List<int> RemoveNumbersThatOccurOddNumbers(List<int> input)
        {
            HashSet<int> whiteList = new HashSet<int>();
            var uniqueValuesInList = new Dictionary<int, int>();
            foreach (var item in input)
            {
                if (uniqueValuesInList.ContainsKey(item))
                {
                    uniqueValuesInList[item]++;
                }
                else
                {
                    uniqueValuesInList.Add(item, 1);
                }
            }

            foreach (var item in uniqueValuesInList)
            {
                if (item.Value % 2 == 0)
                {
                    whiteList.Add(item.Key);
                }
            }

            List<int> result = new List<int>();
            foreach (var item in input)
            {
                if (whiteList.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static void Main()
        {
            List<int> sampleInput = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var result = RemoveNumbersThatOccurOddNumbers(sampleInput);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}