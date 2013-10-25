/* Implement the ADT stack as auto-resizable array. Resize the capacity
 * on demand (when no space is available to add / insert a new element). */

namespace Stack
{
    using System;

    public class StackTests
    {
        public static void Main()
        {
            Stack<int> myTestStack = new Stack<int>();
            myTestStack.Push(11);
            myTestStack.Push(22);
            myTestStack.Push(33);
            myTestStack.Push(44);
            myTestStack.Push(55);

            Console.WriteLine("Peek test: {0}", myTestStack.Peek());
            Console.WriteLine("Peek test: {0}", myTestStack.Peek());
            Console.WriteLine("Peek test: {0}", myTestStack.Peek());
            Console.WriteLine("Pop test: {0}", myTestStack.Pop());
            Console.WriteLine("Pop test: {0}", myTestStack.Pop());
            Console.WriteLine("Pop test: {0}", myTestStack.Pop());
            Console.WriteLine("Pop test: {0}", myTestStack.Pop());
            Console.WriteLine("Pop test: {0}", myTestStack.Pop());
        }
    }
}
