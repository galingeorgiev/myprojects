namespace HashedSet
{
    using System.Collections;
    using HashTable;
    
    public class HashedSet<T>
    {
        private HashTable<T, T> hashSet = new HashTable<T, T>();

        public void Add(T value)
        {
            if (!this.hashSet.Containes(value))
            {
                this.hashSet.Add(value, value);
            }
        }

        public T Find(T value)
        {
            return this.hashSet.Find(value);
        }

        public void Remove(T value)
        {
            this.hashSet.Remove(value);
        }

        public int Count()
        {
            return this.hashSet.Count();
        }

        public void Clear()
        {
            this.hashSet.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.hashSet)
            {
                yield return item;
            }
        }
    }
}
