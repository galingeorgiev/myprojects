/** The majorant of an array of size N is a value that occurs in it at
 * least N/2 + 1 times. Write a program to find the majorant of given
 * array (if exists). Example:
 * {2, 2, 3, 3, 2, 3, 4, 3, 3}  3
*/

namespace FindMajorant
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class FindMajorant
    {
        public static string RemoveNumbersThatOccurOddNumbers(int[] input)
        {
            HashSet<int> whiteList = new HashSet<int>();
            var uniqueValuesInList = new OrderedDictionary<int, int>();
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

            string result = null;
            foreach (var item in uniqueValuesInList)
            {
                if (item.Value >= (uniqueValuesInList.Count / 2) + 1)
                {
                    result = string.Format("Majorant number is {0}.", item.Key);
                }
            }

            if (result == null)
            {
                result = "Does not exist majorant number.";
            }

            return result;
        }

        public static void Main()
        {
            var sampleInput = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var result = RemoveNumbersThatOccurOddNumbers(sampleInput);

            Console.WriteLine(result);
        }
    }
}