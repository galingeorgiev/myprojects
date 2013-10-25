/* Implement a class BiDictionary<K1,K2,T> that allows adding 
 * triples {key1, key2, value} and fast search by key1, key2 
 * or by both key1 and key2. Note: multiple values can be 
 * stored for given key.
 */

namespace BiDictionary
{
    using System;

    public class BiDictionaryTest
    {
        public static void Main()
        {
            BiDictionary<string, string, int> myBiDictionary = new BiDictionary<string, string, int>();
            myBiDictionary.Add("Petyr", "Petrov", 30);
            Console.WriteLine(string.Join(", ", myBiDictionary.GetValueByFirstKey("Petyr")));
            Console.WriteLine(string.Join(", ", myBiDictionary.GetValueBySecondKey("Petrov")));
            Console.WriteLine(string.Join(", ", myBiDictionary.GetValueByBothKeys("Petyr", "Petrov")));
        }
    }
}
