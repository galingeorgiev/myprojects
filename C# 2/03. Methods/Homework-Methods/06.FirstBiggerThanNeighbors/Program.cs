using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static int CheckBiggerNumber(int n, List<int> list)
    {
        if (list[n] > list[n - 1] & list[n] > list[n + 1])
        {
            return 1;
        }
        return -1;
    }
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

        int counter = 1;
        for (int i = 1; i < list.Count - 1; i++)
        {
            if (CheckBiggerNumber(i, list) == 1)
            {
                Console.WriteLine("Index is {0}.", i);
                break;
            }
            else
            {
                counter++;
            }
            if (counter == list.Count - 1)
            {
                Console.WriteLine("-1");
            }
        }
    }
}