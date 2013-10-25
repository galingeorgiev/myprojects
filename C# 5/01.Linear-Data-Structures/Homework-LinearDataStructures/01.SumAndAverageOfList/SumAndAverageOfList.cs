/* Write a program that reads from the console a sequence of
 * positive integer numbers. The sequence ends when empty line
 * is entered. Calculate and print the sum and average of the 
 * elements of the sequence. Keep the sequence in List<int>.
 */

namespace SumAndAverageOfList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverageOfList
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
                input.Add(readedConsoleInput);
            }
            while (isParceSuccess);

            return input;
        }

        public static void Main()
        {
            List<int> input = ReadInput();
            Console.WriteLine("Sum of elements is: {0}", input.Sum());
            Console.WriteLine("Average of elements is: {0:0.00}", input.Average());
        }
    }
}