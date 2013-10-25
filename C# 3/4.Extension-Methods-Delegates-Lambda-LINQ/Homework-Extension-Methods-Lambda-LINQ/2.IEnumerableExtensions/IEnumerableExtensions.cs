/*Implement a set of extension methods for IEnumerable<T> that implement
 *the following group functions: sum, product, min, max, average.*/

using System;
using System.Collections.Generic;

namespace _2.IEnumerableExtensions
{
    static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> elements)
        {
            T result = default(T);
            foreach (var element in elements)
            {
                result = result + (dynamic)element;
            }
            return result;
        }

        public static T Product<T>(this IEnumerable<T> elements)
            where T : struct, IComparable, IComparable<T>, IConvertible, IFormattable, IEquatable<T>
        {
            T result = (dynamic)default(T) + 1;

            foreach (var element in elements)
            {
                result = result * (dynamic)element;
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> elements)
            where T : IComparable, IComparable<T>
        {
            List<T> tempList = new List<T>(elements);
            T result = tempList[0];

            foreach (var element in elements)
            {
                if (element.CompareTo(result) < 0)
                {
                    result = element;
                }
            }
            return result;
        }

        public static T Max<T>(this IEnumerable<T> elements)
            where T : IComparable, IComparable<T>
        {
            List<T> tempList = new List<T>(elements);
            T result = tempList[0];

            foreach (var element in elements)
            {
                if (element.CompareTo(result) > 0)
                {
                    result = element;
                }
            }
            return result;
        }

        public static T Average<T>(this IEnumerable<T> elements)
            where T : struct, IComparable, IComparable<T>, IConvertible, IFormattable, IEquatable<T>
        {
            T result = (dynamic)default(T) + 1;
            List<T> tempList = new List<T>(elements);

            foreach (var element in elements)
            {
                result = result + (dynamic)element;
            }
            return (dynamic)result/tempList.Count;
        }
    }
}
