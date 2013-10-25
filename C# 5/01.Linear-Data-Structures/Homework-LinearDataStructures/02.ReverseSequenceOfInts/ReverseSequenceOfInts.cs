/* Write a program that reads N integers from the console and 
 * reverses them using a stack. Use the Stack<int> class.
 */

namespace ReverseSequenceOfInts
{
    using System;
    using System.Collections.Generic;

    public class ReverseSequenceOfInts
    {
        public static Stack<int> ReadInput()
        {
            var input = new Stack<int>();
            bool isParceSuccess = false;

            Console.WriteLine("Enter integer numbers. For end enter blank line.");

            do
            {
                int readedConsoleInput;
                isParceSuccess = int.TryParse(Console.ReadLine(), out readedConsoleInput);
                if (isParceSuccess)
                {
                    input.Push(readedConsoleInput);
                }
            }
            while (isParceSuccess);

            return input;
        }

        public static void Main()
        {
            Stack<int> input = ReadInput();

            while (input.Count > 0)
            {
                Console.WriteLine(input.Pop());
            }
        }
    }
}