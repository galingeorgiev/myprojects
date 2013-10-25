using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static List<int> ConvertList(List<int> list)
    {
        List<int> result = new List<int>();
        StringBuilder listToStr = new StringBuilder();

        for (int i = 0; i < list.Count; i++)
        {
            listToStr.Append(list[i]);
        }

        char[] listToChar = listToStr.ToString().ToCharArray();

        for (int i = 0; i < listToChar.Length; i++)
        {
            result.Add(int.Parse(listToChar[i].ToString()));
        }

        return result;
    }

    static List<int> MultiplicateArrayAndDigit(int number, List<int> list)
    {
        List<int> result = new List<int>();
        int res = 0;

        for (int i = 0; i < list.Count; i++)
        {
            int temp = (list[list.Count - i - 1] * number) + res;

            if (i == list.Count - 1)
            {
                result.Insert(0, temp);
                break;
            }

            if (temp < 10)
            {
                result.Insert(0, temp);
                res = 0;
            }
            else
            {
                result.Insert(0, temp % 10);
                res = temp / 10;
            }
        }

        result = ConvertList(result);
        return result;
    }

    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        List<int> factorial = new List<int>();
        factorial.Add(1);
        for (int i = 2; i <= n; i++)
        {
            factorial = MultiplicateArrayAndDigit(i, factorial);
        }

        Console.Write("{0}! = ", n);
        foreach (var item in factorial)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}