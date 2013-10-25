namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T>
    {
        private static int startCapacity = 16;
        private LinkedList<KeyValuePair<K, T>>[] hashTable = new LinkedList<KeyValuePair<K, T>>[startCapacity];
        
        public T this[int index]
        {
            get 
            {
                if (this.hashTable[index] == null)
                {
                    throw new NullReferenceException("Element on this index is null.");
                }

                return this.hashTable[index].First.Value.Value; 
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.hashTable.Length; i++)
            {
                if (this.hashTable[i] != null)
                {
                    var elements = this.hashTable[i].First;
                    while (elements != null)
                    {
                        yield return elements.Value.Value;
                        elements = elements.Next;
                    }
                }
            }
        }

        public void Add(K key, T value)
        {
            int countEmpty = this.CountEmpty();
            if (countEmpty >= (int)(startCapacity * 0.75))
            {
                startCapacity = startCapacity * 2;
                LinkedList<KeyValuePair<K, T>>[] biggerHashTable = new LinkedList<KeyValuePair<K, T>>[startCapacity];
                Array.Copy(this.hashTable, biggerHashTable, startCapacity / 2);
                this.hashTable = biggerHashTable;
            }

            int keyHashCode = key.GetHashCode() % startCapacity;
            if (keyHashCode < 0)
            {
                keyHashCode = keyHashCode * -1;
            }

            LinkedList<KeyValuePair<K, T>> currentElement = new LinkedList<KeyValuePair<K, T>>();
            KeyValuePair<K, T> currentKeyValuePair = new KeyValuePair<K, T>(key, value);

            if (this.hashTable[keyHashCode] == null)
            {
                currentElement.AddFirst(currentKeyValuePair);
                this.hashTable[keyHashCode] = currentElement;
            }
            else
            {
                this.hashTable[keyHashCode].AddFirst(currentKeyValuePair);
            }
        }

        public T Find(K key)
        {
            int keyHashCode = key.GetHashCode() % startCapacity;
            if (keyHashCode < 0)
            {
                keyHashCode = keyHashCode * -1;
            }

            if (this.hashTable[keyHashCode] == null)
            {
                throw new ArgumentException("Key not found");
            }
            else
            {
                var currentKeyValuePair = this.hashTable[keyHashCode].First;
                if (currentKeyValuePair != null)
                {
                    while (currentKeyValuePair != null)
                    {
                        if (currentKeyValuePair.Value.Key.Equals(key))
                        {
                            return currentKeyValuePair.Value.Value;
                        }

                        currentKeyValuePair = currentKeyValuePair.Next;
                    }
                }
            }

            throw new ArgumentException("Key not found");
        }

        // This method can be optimaised because now I have repeatable code.
        // But I must found value for delete.
        public void Remove(K key)
        {
            int keyHashCode = key.GetHashCode() % startCapacity;
            if (keyHashCode < 0)
            {
                keyHashCode = keyHashCode * -1;
            }

            if (this.hashTable[keyHashCode] == null)
            {
                throw new ArgumentException("Key not found");
            }
            else
            {
                var currentKeyValuePair = this.hashTable[keyHashCode].First;

                if (currentKeyValuePair != null)
                {
                    while (currentKeyValuePair != null)
                    {
                        if (currentKeyValuePair.Value.Key.Equals(key))
                        {
                            var value = currentKeyValuePair.Value.Value;
                            var elementForDelete = new KeyValuePair<K, T>(key, value);

                            this.hashTable[keyHashCode].Remove(elementForDelete);

                            if (this.hashTable[keyHashCode].First == null)
                            {
                                this.hashTable[keyHashCode] = null;
                            }
                        }

                        currentKeyValuePair = currentKeyValuePair.Next;
                    }
                }
            }
        }

        public int Count()
        {
            int count = 0;

            for (int i = 0; i < this.hashTable.Length; i++)
            {
                if (this.hashTable[i] != null)
                {
                    var elements = this.hashTable[i].First;
                    while (elements != null)
                    {
                        count++;
                        elements = elements.Next;
                    }
                }
            }

            return count;
        }

        public void Clear()
        {
            for (int i = 0; i < this.hashTable.Length; i++)
            {
                this.hashTable[i] = null;
            }
        }

        public List<K> Keys()
        {
            List<K> keys = new List<K>();
            for (int i = 0; i < this.hashTable.Length; i++)
            {
                if (this.hashTable[i] != null)
                {
                    var elements = this.hashTable[i].First;
                    while (elements != null)
                    {
                        keys.Add(elements.Value.Key);
                        elements = elements.Next;
                    }
                }
            }

            return keys;
        }

        public bool Containes(K key)
        {
            bool isKeyFound = false;
            int keyHashCode = key.GetHashCode() % startCapacity;

            if (keyHashCode < 0)
            {
                keyHashCode = keyHashCode * -1;
            }

            if (this.hashTable[keyHashCode] == null)
            {
                return isKeyFound;
            }
            else
            {
                var currentKeyValuePair = this.hashTable[keyHashCode].First;
                if (currentKeyValuePair != null)
                {
                    while (currentKeyValuePair != null)
                    {
                        if (currentKeyValuePair.Value.Key.Equals(key))
                        {
                            isKeyFound = true;
                            break;
                        }

                        currentKeyValuePair = currentKeyValuePair.Next;
                    }
                }
            }

            return isKeyFound;
        }

        private int CountEmpty()
        {
            int count = 0;

            for (int i = 0; i < this.hashTable.Length; i++)
            {
                if (this.hashTable[i] != null)
                {
                    count++;
                }
            }

            return count;
        }
    }
}