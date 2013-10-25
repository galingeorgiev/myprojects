namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            IList<T> sortedList = this.MergeSort(collection);
            collection.Clear();
            foreach (var item in sortedList)
            {
                collection.Add(item);
            }
        }

        private IList<T> MergeSort(IList<T> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int mid = list.Count / 2;

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < mid; i++)
            {
                left.Add(list[i]);
            }

            for (int i = mid; i < list.Count; i++)
            {
                right.Add(list[i]);
            }

            IList<T> sortedList = this.Merge(this.MergeSort(left), this.MergeSort(right));
            return sortedList;
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> rv = new List<T>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0].CompareTo(right[0]) > 0)
                {
                    rv.Add(right[0]);
                    right.RemoveAt(0);
                }
                else
                {
                    rv.Add(left[0]);
                    left.RemoveAt(0);
                }
            }

            for (int i = 0; i < left.Count; i++)
            {
                rv.Add(left[i]);
            }

            for (int i = 0; i < right.Count; i++)
            {
                rv.Add(right[i]);
            }

            return rv;
        }
    }
}
