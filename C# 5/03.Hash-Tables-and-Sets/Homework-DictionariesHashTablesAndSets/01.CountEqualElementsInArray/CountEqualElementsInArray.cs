/* Write a program that counts in a given array of double values
 * the number of occurrences of each value. Use Dictionary<TKey,TValue>.
 * Example: 
 * array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
 * Result:
 * -2.5  2 times
 * 3  4 times
 * 4  3 times
 */

namespace CountEqualElementsInArray
{
    using System;
    using System.Collections.Generic;

    public class CountEqualElementsInArray
    {
        public static void Main()
        {
            double[] values = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            SortedDictionary<double, int> valuesOccurrences = new SortedDictionary<double, int>();

            for (int i = 0; i < values.Length; i++)
            {
                if (valuesOccurrences.ContainsKey(values[i]))
                {
                    valuesOccurrences[values[i]] = valuesOccurrences[values[i]] + 1;
                }
                else
                {
                    valuesOccurrences.Add(values[i], 1);
                }
            }

            foreach (var value in valuesOccurrences)
            {
                Console.WriteLine("{0} -> {1}", value.Key, value.Value);
            }
        }
    }
}
