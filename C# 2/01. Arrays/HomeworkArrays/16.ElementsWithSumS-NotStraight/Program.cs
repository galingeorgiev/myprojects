using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main()
    {
        Console.Write("Searchrd sum is S = ");
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
        FindSearchedSum(n, list);
    }

    static void FindSearchedSum(int n, List<int> list)
    {
        int endOfLoop = (int)Math.Pow(2, list.Count);
        for (int i = 0; i < endOfLoop; i++)
        {
            int sum = 0;
            int tempI = i;
            List<int> elementsOfSum = new List<int>();
            for (int j = 0; j < list.Count; j++)
            {
                int combination = tempI % 2;
                tempI = tempI / 2;
                if (combination == 1)
                {
                    sum = sum + list[j];
                    elementsOfSum.Add(list[j]);
                }
            }
            if (sum == n)
            {
                Console.Write("Elements with sum {0} are: ", n);
                foreach (var item in elementsOfSum)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
            }
            elementsOfSum.Clear();
        }
    }
}