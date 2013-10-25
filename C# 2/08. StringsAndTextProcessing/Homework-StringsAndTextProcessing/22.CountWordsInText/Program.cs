using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        String text = "Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.";
        string[] textToStringArray = text.Split(' ', ',', '.', '!', '?');
        Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

        for (int i = 0; i < textToStringArray.Length; i++)
        {
            string temp = textToStringArray[i].Trim();
            if (dictionary.ContainsKey(temp))
            {
                dictionary[temp] = dictionary[temp] + 1;
            }
            else
            {
                dictionary.Add(temp, 1);
            }
        }

        foreach (var item in dictionary)
        {
            Console.WriteLine("Word \"{0}\" is found {1} times",item.Key, item.Value);
        }
    }
}