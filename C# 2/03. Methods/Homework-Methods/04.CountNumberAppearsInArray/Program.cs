using System;
using System.Collections.Generic;

class Program
{
    static int DigitsRepeatCounter(int n, List<int> list)
    {
        int counter = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == n)
            {
                counter++;
            }
        }
        return counter;
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

        Console.WriteLine("Number {0} appears {1} times.", n, DigitsRepeatCounter(n, list));
    }
}