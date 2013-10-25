using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string text = "abba other word lamal second first third exe fourth";
        string[] textToStringArray = text.Split(' ',',','.','!','?');

        for (int i = 0; i < textToStringArray.Length; i++)
        {
            string word = textToStringArray[i];
            bool isPalindromes = true;
            for (int j = 0; j < word.Length / 2; j++)
            {
                if (word[j] != word[word.Length - j - 1])
                {
                    isPalindromes = false;
                    break;
                }
            }

            if (isPalindromes)
            {
                Console.WriteLine(word);
            }
        }
    }
}