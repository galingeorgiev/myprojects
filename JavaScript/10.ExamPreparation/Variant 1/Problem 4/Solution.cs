using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJustify
{
    class ConsoleJustify
    {
        static int CountLetters(string s)
        {
            int count = 0;
            foreach (var ch in s)
            {
                if (Char.IsLetter(ch))
                {
                    count++;
                }
            }

            return count;
        }

        static string GetFirstWord(string s, int startIndex, out int resultFoundIndex)
        {
            int wordStartIndex = -1;
            int wordEndIndex = -1;
            bool wordStartFound = false;
            for (int i = startIndex; i < s.Length; i++)
            {
                if (wordStartFound)
                {
                    if (Char.IsLetter(s[i]))
                    {
                        wordStartIndex = i;
                        wordStartFound = true;
                    }
                }
                else
                {
                    if (s[i] == ' ')
                    {
                        wordEndIndex = i;
                        break;
                    }
                }
            }

            resultFoundIndex = wordStartIndex;

            return s.Substring(wordStartIndex, wordEndIndex - wordStartIndex);
        }

        static char[] separators = new char[] { ' ' };

        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            int justifiedLength = int.Parse(Console.ReadLine());

            List<string> words = new List<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] currLineWords = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                words.AddRange(currLineWords);
            }

            StringBuilder resultText = new StringBuilder();
            int usedWordsCount = 0;

            //Console.WriteLine("====================debug==================");
            while (usedWordsCount < words.Count)
            {
                int lineLettersCount = 0;
                int lineWordsCount = 0;
                int lineFirstWordInd = usedWordsCount;

                lineWordsCount++;
                usedWordsCount++;
                lineLettersCount += words[lineFirstWordInd].Length;

                for (int wordToUseInd = lineFirstWordInd + 1; wordToUseInd < words.Count; wordToUseInd++)
                {
                    int potentialLineLength = words[wordToUseInd].Length + lineLettersCount + lineWordsCount;
                    if (potentialLineLength < justifiedLength)
                    {
                        lineWordsCount++;
                        usedWordsCount++;
                        lineLettersCount += words[wordToUseInd].Length;
                    }
                    else
                    {
                        break;
                    }
                }

                //Console.WriteLine(lineLettersCount + " " + lineWordsCount);
                int wordSeparations = lineWordsCount - 1;
                if (wordSeparations != 0)
                {
                    int excessSpaces = justifiedLength - lineLettersCount;
                    int minSpacesPerSeparation = excessSpaces / wordSeparations;
                    int lineLastWordInd = lineFirstWordInd + lineWordsCount - 1;
                    int lastAdditionallySpacedWordInd = lineFirstWordInd + (excessSpaces % wordSeparations);
                    string minSpacing = new string(' ', minSpacesPerSeparation);

                    resultText.Append(words[lineFirstWordInd]);

                    for (int i = lineFirstWordInd + 1; i <= lineLastWordInd; i++)
                    {
                        if (i <= lastAdditionallySpacedWordInd)
                        {
                            resultText.Append(' ');
                        }

                        resultText.Append(minSpacing);
                        resultText.Append(words[i]);
                    }

                    resultText.AppendLine();
                }
                else
                {
                    resultText.AppendLine(words[lineFirstWordInd]);
                }
            }
            //Console.WriteLine("===========================================");

            Console.Write(resultText.ToString());
        }
    }
}
