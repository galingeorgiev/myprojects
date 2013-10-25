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
        string firstFilePath = @"../../UsingFiles/04.FIrstFile.txt";
        string secondFilePath = @"../../UsingFiles/02.SecondFile.txt";

        FileStream fs1 = new FileStream(firstFilePath, FileMode.Create);
        fs1.Dispose();

        FileStream fs2 = new FileStream(secondFilePath, FileMode.Create);
        fs2.Dispose();

        using (StreamWriter writeFirstFile = new StreamWriter(firstFilePath, false))
        {
            writeFirstFile.WriteLine("This is Line 1 - Same");
            writeFirstFile.WriteLine("This is Line 22");
            writeFirstFile.WriteLine("This is Line 33");
            writeFirstFile.WriteLine("This is Line 4 - Same");
            writeFirstFile.WriteLine("This is Line 55");
        }

        using (StreamWriter writeSecondFile = new StreamWriter(secondFilePath, false))
        {
            writeSecondFile.WriteLine("This is Line 1 - Same");
            writeSecondFile.WriteLine("This is Line 222");
            writeSecondFile.WriteLine("This is Line 333");
            writeSecondFile.WriteLine("This is Line 4 - Same");
            writeSecondFile.WriteLine("This is Line 555");
        }

        using (StreamReader readFirstFile = new StreamReader(firstFilePath))
        {
            int same = 0;
            int different = 0;

            using (StreamReader readSecondFile = new StreamReader(secondFilePath))
            {
                string lineFirstFile = readFirstFile.ReadLine();
                string lineSecondFile = readSecondFile.ReadLine();

                while (lineFirstFile != null)
                {
                    if (lineFirstFile == lineSecondFile)
                    {
                        same++;
                    }
                    else
                    {
                        different++;
                    }

                    lineFirstFile = readFirstFile.ReadLine();
                    lineSecondFile = readSecondFile.ReadLine();
                }
            }
            Console.WriteLine("Number of same lines are: {0}\nNumber of different lines are: {1}", same, different);
        }
    }
}