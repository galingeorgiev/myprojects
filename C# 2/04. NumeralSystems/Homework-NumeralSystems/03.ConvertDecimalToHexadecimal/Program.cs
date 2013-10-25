using System;
using System.Collections.Generic;


class Program
{
    static char HexadecimalValue(int n)
    {
        switch (n)
        {
            case 0: return '0'; break;
            case 1: return '1'; break;
            case 2: return '2'; break;
            case 3: return '3'; break;
            case 4: return '4'; break;
            case 5: return '5'; break;
            case 6: return '6'; break;
            case 7: return '7'; break;
            case 8: return '8'; break;
            case 9: return '9'; break;
            case 10: return 'A'; break;
            case 11: return 'B'; break;
            case 12: return 'C'; break;
            case 13: return 'D'; break;
            case 14: return 'E'; break;
            case 15: return 'F'; break;
            default: return '0'; break;
        }
    }
    static void Main()
    {
        Console.Write("Enter decimal number: ");
        int decimalNumber = int.Parse(Console.ReadLine());
        List<char> list = new List<char>();
        while (decimalNumber != 0)
        {
            list.Add(HexadecimalValue(decimalNumber % 16));
            decimalNumber = decimalNumber / 16;
        }
        list.Reverse();
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write("{0}", list[i]);
        }
        Console.WriteLine();
    }
}