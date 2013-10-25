/*Write a generic class GenericList<T> that keeps a
*list of elements of some parametric type T. Keep the
*elements of the list in an array with fixed capacity
*which is given as parameter in the class constructor.
*Implement methods for adding element, accessing element
*by index, removing element by index, inserting element
*at given position, clearing the list, finding element by
*its value and ToString(). Check all input parameters to
*avoid accessing elements at invalid positions.*/

using System;
using System.Text;
using System.Collections.Generic;

namespace GenericList
{
    class GenericList<T>
    {
        private T[] genericList;
        private int index = 0;

        //Define constructor
        public GenericList(int size)
        {
            this.genericList = new T[size];
        }

        //Define indexer
        public T this[int index]
        {
            get 
            {
                if (index >= genericList.Length | index < 0)
                {
                    throw new ApplicationException("Index out of range.");
                }
                else
                {
                    return this.genericList[index];
                }
            }
            set
            {
                if (index >= 0 & index < genericList.Length)
                {
                    genericList[index] = value;
                }
                else
                {
                    AutoGrowUp();
                }
            }
        }

        //Define methods
        //Add element in last free position
        public void Add(T element)
        {
            if (genericList[this.index] == null)
            {
                genericList[this.index] = element;
            }
            else
            {
                while (genericList[this.index] != null)
                {
                    this.index++;
                }
                genericList[this.index] = element;
            }
        }

        //Remove element by index. Array is imutable and that is reasons to return new array without one element;
        public void RemoveByIndex(int index)
        {
            if (index >= genericList.Length | index < 0)
            {
                throw new ApplicationException("Index out of range.");
            }
            else
            {
                var tempList = new List<T>(this.genericList);
                tempList.RemoveAt(index);
                for (int i = 0; i < tempList.Count; i++)
                {
                    this.genericList[i] = tempList[i];
                }
            }
        }

        //Insert element at given position
        public void Insert(int index, T item)
        {
            if (index >= genericList.Length | index < 0)
            {
                throw new ApplicationException("Index out of range.");
            }
            else
            {
                var tempList = new List<T>(this.genericList);
                tempList.Insert(index, item);
                for (int i = 0; i < genericList.Length; i++)
                {
                    this.genericList[i] = tempList[i];
                }
            }
        }

        //Clear the list
        public void Clear()
        {
            var tempList = new List<T>(this.genericList);
            tempList.Clear();
            for (int i = 0; i < genericList.Length; i++)
            {
                this.genericList[i] = tempList[i];
            }
        }

        //Find element by its value
        public int IndexOfElement(T element, int startFrom)
        {
            int index = Array.IndexOf(this.genericList, element, startFrom);
            return index;
        }

        //Override ToString()
        public override string ToString()
        {
            StringBuilder textReturn = new StringBuilder();

            foreach (var item in this.genericList)
            {
                textReturn.Append(item);
                textReturn.Append(" ");
            }
            return textReturn.ToString();
        }

        /*Implement auto-grow functionality: when the
        *internal array is full, create a new array of
        *double size and move all elements to it.*/
        private void AutoGrowUp()
        {
            T[] biggesGenericList = new T[this.genericList.Length * 2];
            Array.Copy(this.genericList, biggesGenericList, this.genericList.Length);
        }

        /*Create generic methods Min<T>() and Max<T>()
        *for finding the minimal and maximal element
        *in the  GenericList<T>. You may need to add
        *a generic constraints for the type T.*/

        public T Min<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) <= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public T Max<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) <= 0)
            {
                return second;
            }
            else
            {
                return first;
            }
        }
    }
}