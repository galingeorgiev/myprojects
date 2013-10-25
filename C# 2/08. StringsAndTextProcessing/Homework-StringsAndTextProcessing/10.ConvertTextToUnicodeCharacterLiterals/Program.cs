using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string inputStr = "Hi!";

        for (int i = 0; i < inputStr.Length; i++)
        {
            Console.Write("\\u{0:x4}", (int)inputStr[i]);
        }
        Console.WriteLine();
    }
}