using System;
using System.Collections.Generic;

class Program
{
    static void Min(List<int> list)
    {
        int minValue = int.MaxValue;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] < minValue)
            {
                minValue = list[i];
            }
        }
        Console.WriteLine("Minimum value in this set is : {0}", minValue);
    }

    static void Max(List<int> list)
    {
        int minValue = int.MinValue;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] > minValue)
            {
                minValue = list[i];
            }
        }
        Console.WriteLine("Minimum value in this set is : {0}", minValue);
    }

    static void Average(List<int> list)
    {
        int sum = 0;

        for (int i = 0; i < list.Count; i++)
        {
            sum = sum + list[i];
        }
        Console.WriteLine("Average is: {0:F2}", sum / list.Count);
    }

    static void Sum(List<int> list)
    {
        int sum = 0;

        for (int i = 0; i < list.Count; i++)
        {
            sum = sum + list[i];
        }
        Console.WriteLine("Average is: {0}", sum);
    }

    static void Product(List<int> list)
    {
        int product = 1;

        for (int i = 0; i < list.Count; i++)
        {
            product = product * list[i];
        }
        Console.WriteLine("Product is: {0}", product);
    }

    static void Main()
    {
        List<int> list = new List<int>();
        Console.WriteLine("Enter array elements: \nFor end enter 'n'");
        while (true)
        {
            string numberStr = Console.ReadLine();
            int value;
            bool isNum = int.TryParse(numberStr, out value);
            if (isNum)
            {
                list.Add(value);
            }
            else
            {
                break;
            }
        }

        Console.Write("To calculate\nMinimum press 1\nMaximum press 2\nAverage press 3\nSum press 4\nProduct press 5\nYour choice is: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Min(list);
                break;
            case 2:
                Max(list);
                break;
            case 3:
                Average(list);
                break;
            case 4:
                Sum(list);
                break;
            case 5:
                Product(list);
                break;
            default:
                Console.WriteLine("Enter value between 1-5");
                break;
        }
    }
}