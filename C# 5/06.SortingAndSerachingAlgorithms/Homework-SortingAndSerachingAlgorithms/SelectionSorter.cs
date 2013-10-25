namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            T minValue;
            int minValuePosition = 0;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                minValue = collection[i];
                minValuePosition = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(minValue) == -1)
                    {
                        minValue = collection[j];
                        minValuePosition = j;
                    }
                }

                T tempOldValue = collection[minValuePosition];
                collection[minValuePosition] = collection[i];
                collection[i] = tempOldValue;
            }
        }
    }
}
