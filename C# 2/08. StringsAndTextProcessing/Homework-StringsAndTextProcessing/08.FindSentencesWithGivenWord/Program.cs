using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string inputStr = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string searchedWord = " in ";

        string[] splitSentences = inputStr.Split('.');

        int index = 0;

        for (int i = 0; i < splitSentences.Length; i++)
        {
            int indexOfSearchesWord = splitSentences[i].IndexOf(searchedWord,index);

            if (indexOfSearchesWord >= 0)
            {
                
                    Console.Write(splitSentences[i].Trim());
                    Console.WriteLine(".");
                
            }
        }
    }
}