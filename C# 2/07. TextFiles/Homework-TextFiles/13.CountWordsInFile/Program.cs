using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string test = @"../../UsingFiles/test.txt";
        string words = @"../../UsingFiles/words.txt";
        string result = @"../../UsingFiles/result.txt";

        try
        {
            FileStream fsTest = new FileStream(test, FileMode.Create);
            fsTest.Dispose();

            FileStream fsWords = new FileStream(words, FileMode.Create);
            fsWords.Dispose();

            FileStream fsResult = new FileStream(result, FileMode.Create);
            fsResult.Dispose();

            using (StreamWriter writeTestContent = new StreamWriter(test, false))
            {
                writeTestContent.WriteLine("You heard about this crazy thing called computer programming that will allow you to create your own software and now..you're really curious.");
                writeTestContent.WriteLine("This section contains tutorials on a variety of computer programming topics including what computer programming is, computer programming concepts.");
                writeTestContent.WriteLine("Test your knowledge of this section with the Introduction to computer programming quiz");
                writeTestContent.WriteLine("When you are ready to actually learn a computer programming language, check out our Java tutorials.");
            }

            using (StreamWriter writeListOfWords = new StreamWriter(words, false))
            {
                writeListOfWords.WriteLine("heard");
                writeListOfWords.WriteLine("section");
                writeListOfWords.WriteLine("learn");
                writeListOfWords.WriteLine("your");
                writeListOfWords.WriteLine("the");
            }

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            using (StreamReader readInputFile = new StreamReader(test))
            {
                string line = readInputFile.ReadLine();

                while (line != null)
                {
                    StreamReader readListOfWords = new StreamReader(words);
                    string listOfWords = readListOfWords.ReadLine();
                    string[] lineToStringArray = line.Split(' ', ',', '.', '!', '?');

                    while (listOfWords != null)
                    {
                        for (int i = 0; i < lineToStringArray.Length; i++)
                        {
                            string temp = lineToStringArray[i].Trim();
                            if (temp == listOfWords)
                            {
                                if (dictionary.ContainsKey(temp))
                                {
                                    dictionary[temp] = dictionary[temp] + 1;
                                }
                                else
                                {
                                    dictionary.Add(temp, 1);
                                }
                            }
                        }
                        listOfWords = readListOfWords.ReadLine();
                    }

                    line = readInputFile.ReadLine();
                    readListOfWords.Dispose();
                }
            }

            var sortedDict = (from entry in dictionary orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            using (StreamWriter writeResults = new StreamWriter(result))
            {
                foreach (var item in sortedDict)
                {
                    writeResults.WriteLine("Word \"{0}\" is found {1} times", item.Key, item.Value);
                }
            }

            Console.WriteLine("Job is DONE!");
        }
        catch (FileNotFoundException fnfe)
        {
            Console.Error.WriteLine("{0}\n\n{1}", fnfe.Message, fnfe.StackTrace);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.Error.WriteLine("{0}\n\n{1}", dnfe.Message, dnfe.StackTrace);
        }
        catch (PathTooLongException ptle)
        {
            Console.Error.WriteLine("{0}\n\n{1}", ptle.Message, ptle.StackTrace);
        }
        catch (EndOfStreamException eose)
        {
            Console.Error.WriteLine("{0}\n\n{1}", eose.Message, eose.StackTrace);
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("{0}\n\n{1}", fe.Message, fe.StackTrace);
        }
        catch (InternalBufferOverflowException ibofe)
        {
            Console.Error.WriteLine("{0}\n\n{1}", ibofe.Message, ibofe.StackTrace);
        }
        catch (IOException ioe)
        {
            Console.Error.WriteLine("{0}\n\n{1}", ioe.Message, ioe.StackTrace);
        }
        catch (OverflowException ofe)
        {
            Console.Error.WriteLine("{0}\n\n{1}", ofe.Message, ofe.StackTrace);
        }
        catch (OutOfMemoryException ofme)
        {
            Console.Error.WriteLine("{0}\n\n{1}", ofme.Message, ofme.StackTrace);
        }
        catch (ArgumentNullException ane)
        {
            Console.Error.WriteLine("{0}\n\n{1}", ane.Message, ane.StackTrace);
        }
        catch (ArgumentException ae)
        {
            Console.Error.WriteLine("{0}\n\n{1}", ae.Message, ae.StackTrace);
        }
        catch (StackOverflowException sofe)
        {
            Console.Error.WriteLine("{0}\n\n{1}", sofe.Message, sofe.StackTrace);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("{0}\n\n{1}", e.Message, e.StackTrace);
        }
    }
}