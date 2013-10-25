using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        if (number < 0)
        {
            int inversedNumber = (short.MinValue - number) * (-1);
            List<int> list = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(inversedNumber % 2);
                inversedNumber = inversedNumber / 2;
            }
            list.Reverse();
            Console.Write("1");
            foreach (var item in list)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
        else
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(number % 2);
                number = number / 2;
            }
            list.Reverse();
            Console.Write("0");
            foreach (var item in list)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

    }
}