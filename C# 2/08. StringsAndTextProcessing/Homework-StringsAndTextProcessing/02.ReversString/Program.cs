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
        Console.Write("{0} -> ",str);
        char[] reversedStr = str.ToCharArray();
        Array.Reverse(reversedStr);
        Console.WriteLine(reversedStr);
    }
}