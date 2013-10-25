using System;
using System.Collections.Generic;


class Program
{
    static void CheckBiggerNumber(int n, List<int> list)
    {
        n = n - 1;
        if (n >= list.Count)
        {
            Console.WriteLine("Doesn't exist element in this position.");
        }
        if (n + 1 >= list.Count)
        {
            Console.WriteLine("Doesn't exist right neighbor.");
        }
        if (n - 1 < 0)
        {
            Console.WriteLine("Doesn't exist left neighbor.");
        }
        if (list[n] > list[n - 1] & list[n] > list[n + 1])
        {
            Console.WriteLine("Number {0} is bigger from {1} and {2}.", list[n], list[n - 1], list[n + 1]);
        }
        else
        {
            Console.WriteLine("Number {0} is less from {1} or {2}.", list[n], list[n - 1], list[n + 1]);
        }
    }

    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        Console.WriteLine("Enter array elements: \nFor end enter 'n'");
        while (true)
        {
            string number = Console.ReadLine();
            int value;
            bool isNum = int.TryParse(number, out value);
            if (isNum)
            {
                list.Add(value);
            }
            else
            {
                break;
            }
        }

        CheckBiggerNumber(n, list);
    }
}