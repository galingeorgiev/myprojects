using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Dictionary<char,int> upperLetter = new Dictionary<char,int>();
        for (int i = 0; i < 26; i++)
        {
            upperLetter.Add((char)(65 + i), i);
        }

        Dictionary<char, int> lowerLetter = new Dictionary<char, int>();
        for (int i = 0; i < 6; i++)
        {
            lowerLetter.Add((char)(97 + i), 26*(i + 1));
        }

        string inputDurankulakNumber = Console.ReadLine();

        if (inputDurankulakNumber.Length == 1)
        {
            Console.WriteLine(upperLetter[Convert.ToChar(inputDurankulakNumber)]);
        }
        else
        {
            long result = 0L;

            string pattern = @"[a-z][A-Z]|[A-Z]";
            var matchSymbols = Regex.Match(inputDurankulakNumber,pattern);

            List<string> mLetters = new List<string>();
            while (matchSymbols.Success)
            {
                mLetters.Add(matchSymbols.ToString());
                matchSymbols = matchSymbols.NextMatch();
            }

            for (int i = 0; i < mLetters.Count; i++)
            {
                if (mLetters[mLetters.Count - i - 1].Length == 1)
                {
                    result = result + (long)Math.Pow(168, i) * (long)(upperLetter[Convert.ToChar(mLetters[mLetters.Count - i - 1][0])]);
                }
                else
                {
                    result = result + (long)Math.Pow(168, i) * (long)( lowerLetter[ Convert.ToChar( mLetters[mLetters.Count - i - 1][0] ) ] + upperLetter[Convert.ToChar(mLetters[mLetters.Count - i - 1][1])]);
                }
            }

            Console.WriteLine(result);
        }



        /*
        bool isInCombination = false;
        long result = 0L;

        for (int i = 0; i < inputDurankulakNumber.Length; i++)
        {
            if (char.IsUpper(inputDurankulakNumber[inputDurankulakNumber.Length - i - 1]))
            {
                if (i > 0)
                {
                    if (char.IsLower(inputDurankulakNumber[inputDurankulakNumber.Length - i - 2]))
                    {
                        isInCombination = true;
                        result = result + (long)Math.Pow(168, i) * (upperLetter[Convert.ToChar(inputDurankulakNumber[inputDurankulakNumber.Length - i - 1])] + upperLetter[Convert.ToChar(inputDurankulakNumber[inputDurankulakNumber.Length - i - 2])]);
                    }
                }
            }
        }
        */

    }
}