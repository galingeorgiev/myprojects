/* Write a program that finds in given array of integers
 * (all belonging to the range [0..1000]) how many times each of them occurs.
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2  2 times
 * 3  4 times
 * 4  3 times
 */

namespace OccursNumbrersInArray
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class OccursNumbrersInArray
    {
        public static OrderedDictionary<int, int> FindOccursNumbrersInArray(int[] input)
        {
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

            return uniqueValuesInList;
        }

        public static void Main()
        {
            var sampleInput = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var result = FindOccursNumbrersInArray(sampleInput);

            foreach (var item in result)
            {
                Console.WriteLine("{0} -> {1}times.", item.Key, item.Value);
            }
        }
    }
}