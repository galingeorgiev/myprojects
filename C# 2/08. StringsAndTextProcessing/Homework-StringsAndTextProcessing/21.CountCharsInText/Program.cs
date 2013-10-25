using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string text = "Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.";

        int[] charsCount = new int[65536];

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetterOrDigit(text[i]))
            {
                int charPlace = (int)text[i];

                charsCount[charPlace] = charsCount[charPlace] + 1;
            }
        }

        for (int i = 0; i < charsCount.Length; i++)
        {
            if (charsCount[i] > 0)
            {
                Console.WriteLine("Char {0} is found {1} times", (char)i, charsCount[i]);
            }
        }
    }
}