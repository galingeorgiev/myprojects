using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";
        char curentChar = text[0];
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length - 1; i++)
        {
            
            if (curentChar != text[i + 1])
            {
                sb.Append(curentChar.ToString());
                curentChar = text[i + 1];
            }
        }

        Console.Write(sb);

        if (sb[sb.Length - 1] != text[text.Length - 1])
        {
            Console.WriteLine(text[text.Length - 1]);
        }

        Console.WriteLine();
    }
}