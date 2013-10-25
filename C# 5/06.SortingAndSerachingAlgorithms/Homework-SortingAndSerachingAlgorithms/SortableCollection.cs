namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool isFound = false;

            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        public bool BinarySearch(T item)
        {
            bool isFound = false;

            int high, low, mid;
            high = this.items.Count - 1;
            low = 0;
            if (this.items[0].Equals(item))
            {
                return true;
            }
            else if (this.items[high].Equals(item))
            {
                return true;
            }
            else
            {
                while (low <= high)
                {
                    mid = (high + low) / 2;
                    if (this.items[mid].CompareTo(item) == 0)
                    {
                        return true;
                    }
                    else if (this.items[mid].CompareTo(item) > 0)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                return isFound;
            } 
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            var n = this.items.Count;
            for (var i = 0; i < n; i++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                int r = i + rnd.Next(0, n - i);
                T temp = this.items[i];
                this.items[i] = this.items[r];
                this.items[r] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
