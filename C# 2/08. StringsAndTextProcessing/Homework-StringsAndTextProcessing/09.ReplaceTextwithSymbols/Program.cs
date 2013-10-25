using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string inputStr = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        string[] forbidenWords = new string[] { "PHP", "CLR", "Microsoft" };

        for (int i = 0; i < forbidenWords.Length; i++)
        {
            string replaceAsterisk = new string('*', forbidenWords[i].Length);
            inputStr = inputStr.Replace(forbidenWords[i], replaceAsterisk);
        }

        Console.WriteLine(inputStr);
    }
}