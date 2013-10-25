using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Console.Write("Enter decimal number: ");
        int decimalNumber = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        while (decimalNumber != 0)
        {
            list.Add(decimalNumber % 2);
            decimalNumber = decimalNumber / 2;
        }
        list.Reverse();
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write("{0}", list[i]);
        }
        Console.WriteLine();
    }
}