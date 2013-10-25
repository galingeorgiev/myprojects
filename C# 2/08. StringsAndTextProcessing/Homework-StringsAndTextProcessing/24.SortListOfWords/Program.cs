using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Enter words separeted by space: ");
        string words = Console.ReadLine();
        string[] wordsArray = words.Split(' ');
        List<string> listOfWords = new List<string>(wordsArray);
        listOfWords.Sort();

        foreach (var item in listOfWords)
        {
            Console.WriteLine(item);
        }
    }
}