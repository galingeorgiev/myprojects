/* Implement the data structure "hash table" in a class HashTable<K,T>.
 * Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) 
 * with initial capacity of 16. When the hash table load runs over 75%, perform resizing
 * to 2 times larger capacity. Implement the following methods and properties:
 * Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys. 
 * Try to make the hash table to support iterating over its elements with foreach.
 */

namespace HashTable
{
    using System;

    public class HashTableTest
    {
        public static void Main()
        {
            // Create HashTable and add few elements.
            var hashtableTest = new HashTable<int, string>();
            hashtableTest.Add(1, "One");
            hashtableTest.Add(11, "Eleven");
            hashtableTest.Add(2, "Two");
            hashtableTest.Add(3, "Three");

            Console.WriteLine("---------- Test Find(1) ----------");
            Console.WriteLine(hashtableTest.Find(1));

            Console.WriteLine("\n---------- Test Remove(1) ----------");
            hashtableTest.Remove(1);

            Console.WriteLine("\n---------- Test Count() ----------");
            Console.WriteLine(hashtableTest.Count());

            Console.WriteLine("\n---------- Test get all Keys() and print ----------");
            var listOfKeys = hashtableTest.Keys();
            foreach (var item in listOfKeys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n---------- Test foreach ----------");
            foreach (var item in hashtableTest)
            {
                Console.WriteLine(item);
            }

            // If index is empty this will throw new NullReferenceException.
            Console.WriteLine("\n---------- Test this[0] ----------");
            Console.WriteLine(hashtableTest[2]);

            Console.WriteLine("\n---------- Test Clear() and print count ----------");
            hashtableTest.Clear();
            Console.WriteLine(hashtableTest.Count());
        }
    }
}
