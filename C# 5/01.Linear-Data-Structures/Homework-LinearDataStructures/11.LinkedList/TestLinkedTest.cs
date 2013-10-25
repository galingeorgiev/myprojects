/* Implement the data structure linked list. Define a class ListItem<T> 
 * that has two fields: value (of type T) and nextItem (of type ListItem<T>).
 * Define additionally a class LinkedList<T> with a single field firstElement 
 * (of type ListItem<T>). */

namespace LinkedList
{
    using System;

    public class TestLinkedTest
    {
        public static void Main()
        {
            LinkedList<int> myTestLinkedList = new LinkedList<int>();
            myTestLinkedList.AddFirst(1);
            myTestLinkedList.AddLast(2);
            myTestLinkedList.AddLast(3);
            myTestLinkedList.AddLast(2);
            myTestLinkedList.AddLast(6);
            myTestLinkedList.AddLast(4);

            ListItem<int> itemInMiddle = myTestLinkedList.Find(3);
            myTestLinkedList.AddAfter(itemInMiddle, 10);

            myTestLinkedList.AddFirst(100);

            ListItem<int> currItem = myTestLinkedList.FirstElement;

            while (currItem.NextItem != null)
            {
                Console.WriteLine(currItem.Value);

                currItem = currItem.NextItem;
            }

            Console.WriteLine(currItem.Value);
        }
    }
}