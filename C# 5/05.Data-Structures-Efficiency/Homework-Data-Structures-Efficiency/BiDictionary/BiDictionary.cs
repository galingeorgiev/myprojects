namespace BiDictionary
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> firstDictionary = new MultiDictionary<K1, T>(true);
        private MultiDictionary<K2, T> secondDictionary = new MultiDictionary<K2, T>(true);

        public void Add(K1 key, T value)
        {
            this.firstDictionary.Add(key, value);
        }

        public void Add(K1 firstKey, K2 secondKey, T value)
        {
            this.firstDictionary.Add(firstKey, value);
            this.secondDictionary.Add(secondKey, value);
        }

        public ICollection<T> GetValueByFirstKey(K1 key)
        {
            if (this.firstDictionary.ContainsKey(key))
            {
                return this.firstDictionary[key];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public ICollection<T> GetValueBySecondKey(K2 key)
        {
            if (this.secondDictionary.ContainsKey(key))
            {
                return this.secondDictionary[key];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public ICollection<T> GetValueByBothKeys(K1 firstKey, K2 secondKey)
        {
            if (this.firstDictionary.ContainsKey(firstKey) && this.secondDictionary.ContainsKey(secondKey))
            {
                var firstDictionaryValues = this.firstDictionary[firstKey];
                var secondDictionaryValues = this.secondDictionary[secondKey];

                HashSet<T> uniqueValues = new HashSet<T>(firstDictionaryValues);
                uniqueValues.IntersectWith(secondDictionaryValues);

                return uniqueValues;
            }
            else
            {
                throw new KeyNotFoundException("One or both keys not found.");
            }
        }
    }
}
