using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
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

        Console.Write("Searchrd element is: ");
        int n = int.Parse(Console.ReadLine());

        list.Sort();
        int index = list.BinarySearch(n);

        Console.WriteLine("Index of searched element is: {0}", list[index]);
    }
}