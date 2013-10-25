/* Write a program that counts how many times each word from given text file words.txt appears in it.
 * The character casing differences should be ignored. The result words should be ordered 
 * by their number of occurrences in the text.
 * Example:
 * This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
 * Result:
 *  is  2
 *  the  2
 *  this  3
 *  text  6
 */

namespace CountWordsInTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class CountWordsInTextFile
    {
        public static void Main()
        {
            Dictionary<string, int> valuesOccurrences = new Dictionary<string, int>();

            string filePath = "../../TextFiles/words.txt";
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    List<string> wordsInLine = new List<string>(); 
                    line = line.ToLower();
                    StringBuilder currentWord = new StringBuilder();

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (char.IsLetter(line[i]))
                        {
                            currentWord.Append(line[i]);
                        }
                        else if (currentWord.Length > 0)
                        {
                            wordsInLine.Add(currentWord.ToString());
                            currentWord.Clear();
                        }
                    }

                    for (int i = 0; i < wordsInLine.Count; i++)
                    {
                        if (valuesOccurrences.ContainsKey(wordsInLine[i]))
                        {
                            valuesOccurrences[wordsInLine[i]] = valuesOccurrences[wordsInLine[i]] + 1;
                        }
                        else
                        {
                            valuesOccurrences.Add(wordsInLine[i], 1);
                        }
                    }
                }
            }

            var sortDictionaryByValue = from pair in valuesOccurrences
                        orderby pair.Value ascending
                        select pair;

            foreach (var value in sortDictionaryByValue)
            {
                Console.WriteLine("{0} -> {1}", value.Key, value.Value);
            }
        }
    }
}
