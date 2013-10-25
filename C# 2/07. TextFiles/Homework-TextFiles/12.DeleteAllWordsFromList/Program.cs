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
        string input = @"../../UsingFiles/Input.txt";
        string fileWithWords = @"../../UsingFiles/FileWithWords.txt";
        string tempFile = @"../../UsingFiles/Temp.txt";

        try
        {
            FileStream fs = new FileStream(input, FileMode.Create);
            fs.Dispose();

            FileStream fsWords = new FileStream(fileWithWords, FileMode.Create);
            fsWords.Dispose();

            FileStream fsTemp = new FileStream(tempFile, FileMode.Create);
            fsTemp.Dispose();

            using (StreamWriter writeContent = new StreamWriter(input, false))
            {
                writeContent.WriteLine("You heard about this crazy thing called computer programming that will allow you to create your own software and now..you're really curious.");
                writeContent.WriteLine("This section contains tutorials on a variety of computer programming topics including what computer programming is, computer programming concepts.");
                writeContent.WriteLine("Test your knowledge of this section with the Introduction to computer programming quiz");
                writeContent.WriteLine("When you are ready to actually learn a computer programming language, check out our Java tutorials.");
            }

            using (StreamWriter writeListOfWords = new StreamWriter(fileWithWords, false))
            {
                writeListOfWords.WriteLine("heard");
                writeListOfWords.WriteLine("section");
                writeListOfWords.WriteLine("learn");
                writeListOfWords.WriteLine("your");
                writeListOfWords.WriteLine("the");
            }

            using (StreamWriter writeNewFileWithoutListOfwords = new StreamWriter(tempFile,false))
            {
                using (StreamReader readInputFile = new StreamReader(input))
                {
                    string line = readInputFile.ReadLine();
                    
                    while (line != null)
                    {
                        StreamReader readListOfWords = new StreamReader(fileWithWords);
                        string listOfWords = readListOfWords.ReadLine();
                        string lineWithoutWords = line;

                        while (listOfWords != null)
                        {
                            lineWithoutWords = lineWithoutWords.Replace(listOfWords, "");
                            listOfWords = readListOfWords.ReadLine();
                        }

                        writeNewFileWithoutListOfwords.WriteLine(lineWithoutWords);
                        line = readInputFile.ReadLine();
                        readListOfWords.Dispose();
                    }
                }
            }

            File.Delete(input);
            File.Move(tempFile, input);
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