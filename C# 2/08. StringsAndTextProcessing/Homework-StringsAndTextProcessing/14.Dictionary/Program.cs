using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string textLines = ".NET – platform for applications from Microsoft\nCLR – managed execution environment for .NET\nnamespace – hierarchical organization of classes";

        string[] textLinesArray = textLines.Split('\n');
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        for (int i = 0; i < textLinesArray.Length; i++)
        {
            int index = textLinesArray[i].IndexOf('–', 0);
            if (index >= 0)
            {
                string key = textLinesArray[i].Substring(0, index);
                key = key.Trim();
                string value = textLinesArray[i].Substring(index + 1);
                value = value.Trim();

                dictionary.Add(key, value);
            }
        }

        Console.Write("Enter searched word: ");
        string searchedWord = Console.ReadLine();

        if (dictionary.ContainsKey(searchedWord))
        {
            string value = dictionary[searchedWord];
            Console.WriteLine("{0} - {1}", searchedWord,value);
        }
        else
        {
            Console.WriteLine("Cann't find word {0}", searchedWord);
        }
    }
}