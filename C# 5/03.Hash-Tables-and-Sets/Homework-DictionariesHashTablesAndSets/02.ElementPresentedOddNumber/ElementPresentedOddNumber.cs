/* Write a program that extracts from a given sequence of 
 * strings all elements that present in it odd number of times. 
 * Example:
 * {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
 */

namespace ElementPresentedOddNumber
{
    using System;
    using System.Collections.Generic;

    public class ElementPresentedOddNumber
    {
        public static void Main()
        {
            string[] values = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            SortedDictionary<string, int> valuesOccurrences = new SortedDictionary<string, int>();

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

            List<string> elementsPresentedOddNumber = new List<string>();

            foreach (var value in valuesOccurrences)
            {
                if (value.Value % 2 != 0)
                {
                    elementsPresentedOddNumber.Add(value.Key);
                }
            }

            Console.WriteLine("{ " + string.Join(", ", elementsPresentedOddNumber) + " }");
        }
    }
}
