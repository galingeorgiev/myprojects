/* Implement a class PriorityQueue<T> based on the data structure "binary heap". */

namespace PriorityQueue
{
    using System;

    public class PriorityQueueTest
    {
        public static void Main()
        {
            PriorityQueue myTestPriorityQueue = new PriorityQueue();
            myTestPriorityQueue.AddElement(6);
            myTestPriorityQueue.AddElement(1);
            myTestPriorityQueue.AddElement(3);
            myTestPriorityQueue.AddElement(5);
            myTestPriorityQueue.AddElement(4);
            myTestPriorityQueue.AddElement(2);
            myTestPriorityQueue.AddElement(8);
            myTestPriorityQueue.AddElement(9);
            myTestPriorityQueue.AddElement(7);

            int getNine = myTestPriorityQueue.GetElement();
            int getEight = myTestPriorityQueue.GetElement();
            int getSeven = myTestPriorityQueue.GetElement();
            int getSix = myTestPriorityQueue.GetElement();
            int getFive = myTestPriorityQueue.GetElement();
            int getFour = myTestPriorityQueue.GetElement();
            int getThree = myTestPriorityQueue.GetElement();
            int getTwo = myTestPriorityQueue.GetElement();
            int getOne = myTestPriorityQueue.GetElement();

            Console.WriteLine(getNine);
            Console.WriteLine(getEight);
            Console.WriteLine(getSeven);
            Console.WriteLine(getSix);
            Console.WriteLine(getFive);
            Console.WriteLine(getFour);
            Console.WriteLine(getThree);
            Console.WriteLine(getTwo);
            Console.WriteLine(getOne);

            // Uncomment line below to test get element from empty queue.
            // Will throw exception.
            // int getMissingElement = myTestPriorityQueue.GetElement();
        }
    }
}
