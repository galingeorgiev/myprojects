using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string inputStr = "C# is not C++, not PHP and not Delphi!";
        string[] inputStrToArray = inputStr.Split(' ',',','.','!','?','-');
        List<string> inputStrTrimed = new List<string>();
        List<char> symbols = new List<char>();

        for (int i = 0; i < inputStr.Length; i++)
        {
            if (!char.IsLetterOrDigit(inputStr[i]) & inputStr[i] != '#' & inputStr[i] != '+')
            {
                symbols.Add(inputStr[i]);
            }
        }

        for (int i = 0; i < inputStrToArray.Length; i++)
        {
            if (inputStrToArray[i] != String.Empty)
            {
                inputStrTrimed.Add(inputStrToArray[i]);
            }
        }

        for (int i = 0; i < inputStrTrimed.Count; i++)
        {
            Console.Write(inputStrTrimed[inputStrTrimed.Count - i - 1]);
            Console.Write(symbols[i]);
        }
        Console.WriteLine(symbols[inputStrTrimed.Count]);
    }
}