using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string str = Console.ReadLine();

        if (str.Length > 20)
        {
            Console.WriteLine("You enter too long string!");
        }

        if (str.Length == 20)
        {
            Console.WriteLine(str);
        }

        char[] strToChars = new char[20];

        if (str.Length < 20)
        {
            for (int i = 0; i < str.Length; i++)
            {
                strToChars[i] = str[i];
            }

            for (int j = str.Length; j < strToChars.Length; j++)
            {
                strToChars[j] = '*';
            }
        }

        Console.WriteLine(strToChars);
    }
}