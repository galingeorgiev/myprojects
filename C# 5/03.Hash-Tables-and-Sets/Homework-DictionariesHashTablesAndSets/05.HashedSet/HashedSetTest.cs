/* Implement the data structure "set" in a class HashedSet<T> using your class
 * HashTable<K,T> to hold the elements. Implement all standard set operations
 * like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.
 */

namespace HashedSet
{
    using System;

    public class HashedSetTest
    {
        public static void Main()
        {
            // Input array that contains three duplicate strings.
            string[] arrayWithDuplicatedValues = { "cat", "dog", "cat", "leopard", "tiger", "cat" };

            // Display the array.
            Console.WriteLine("---------- Array with duplicated items ----------");
            Console.WriteLine(string.Join(",", arrayWithDuplicatedValues));

            // Use HashSet constructor to ensure unique strings.
            var hashedSet = new HashedSet<string>();
            for (int i = 0; i < arrayWithDuplicatedValues.Length; i++)
            {
                hashedSet.Add(arrayWithDuplicatedValues[i]);
            }

            // Display the resulting array.
            Console.WriteLine("\n---------- HashedSet without duplicated items ----------");
            foreach (var item in hashedSet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n---------- Test Find(cat) ----------");
            Console.WriteLine(hashedSet.Find("cat"));

            Console.WriteLine("\n---------- Test Remove(cat) and print all elements again ----------");
            hashedSet.Remove("cat");
            foreach (var item in hashedSet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n---------- Test Count() ----------");
            Console.WriteLine(hashedSet.Count());

            Console.WriteLine("\n---------- Test Clear() and print count ----------");
            hashedSet.Clear();
            Console.WriteLine(hashedSet.Count());
        }
    }
}
