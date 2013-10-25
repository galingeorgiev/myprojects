/* Write a program that reads a sequence of integers (List<int>) 
 * ending with an empty line and sorts them in an increasing order.
 */

namespace SortList
{
    using System;
    using System.Collections.Generic;

    public class SortList
    {
        public static List<int> ReadInput()
        {
            var input = new List<int>();
            bool isParceSuccess = false;

            Console.WriteLine("Enter integer numbers. For end enter blank line.");

            do
            {
                int readedConsoleInput = 0;
                isParceSuccess = int.TryParse(Console.ReadLine(), out readedConsoleInput);
                if (isParceSuccess)
                {
                    input.Add(readedConsoleInput);
                }
            }
            while (isParceSuccess);

            return input;
        }

        public static void Main()
        {
            List<int> input = ReadInput();
            input.Sort();

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}