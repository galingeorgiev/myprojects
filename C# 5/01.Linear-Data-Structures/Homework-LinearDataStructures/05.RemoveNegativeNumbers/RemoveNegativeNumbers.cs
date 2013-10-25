/* Write a program that removes from given sequence all negative numbers. */

namespace RemoveNegativeNumbersInList
{
    using System;
    using System.Collections.Generic;

    public class RemoveNegativeNumbersInList
    {
        public static List<int> RemoveNegativeNumbers(List<int> input)
        {
            List<int> listWithoutNegativeNumbers = new List<int>();

            foreach (var item in input)
            {
                if (item >= 0)
                {
                    listWithoutNegativeNumbers.Add(item);
                }
            }

            return listWithoutNegativeNumbers;
        }

        public static void Main()
        {
            List<int> sampleInput = new List<int>() { 1, 5, -4, 3, -2, -1, 5 };
            List<int> sampleInputWithoutNegativeNumbers = RemoveNegativeNumbers(sampleInput);

            Console.WriteLine(string.Join(", ", sampleInputWithoutNegativeNumbers));
        }
    }
}