/* Implement the ADT queue as dynamic linked list. Use generics 
 * (LinkedQueue<T>) to allow storing different data types in the queue. */

namespace LinkedQueue
{
    using System;

    public class LinkedQueueTests
    {
        public static void Main()
        {
            LinkedQueue<int> myTestLinkedQueue = new LinkedQueue<int>();
            myTestLinkedQueue.Enqueue(11);
            myTestLinkedQueue.Enqueue(22);
            myTestLinkedQueue.Enqueue(33);
            myTestLinkedQueue.Enqueue(44);
            myTestLinkedQueue.Enqueue(55);

            Console.WriteLine("Dequeue test: {0}", myTestLinkedQueue.Dequeue());
            Console.WriteLine("Dequeue test: {0}", myTestLinkedQueue.Dequeue());
            Console.WriteLine("Dequeue test: {0}", myTestLinkedQueue.Dequeue());
            Console.WriteLine("Dequeue test: {0}", myTestLinkedQueue.Dequeue());
            Console.WriteLine("Dequeue test: {0}", myTestLinkedQueue.Dequeue());
        }
    }
}
