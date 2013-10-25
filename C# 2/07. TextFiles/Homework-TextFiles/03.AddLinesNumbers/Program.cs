using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static void Main()
    {
        string fileWithoutLineNumbers = @"../../UsingFiles/03.WithoutLineNumbers.txt";
        FileStream fs = new FileStream(fileWithoutLineNumbers, FileMode.Create);
        fs.Dispose();

        string fileWithLineNumbers = @"../../UsingFiles/03.WithLineNumbers.txt";
        FileStream firstFile = new FileStream(fileWithLineNumbers, FileMode.Create);
        firstFile.Dispose();

        using (StreamWriter writeFirstFile = new StreamWriter(fileWithoutLineNumbers, false))
        {
            for (int i = 0; i < 10; i++)
            {
                writeFirstFile.WriteLine("line");
            }
        }

        using (StreamWriter writeNewFile = new StreamWriter(fileWithLineNumbers, false))
        {
            using (StreamReader readFile = new StreamReader(fileWithoutLineNumbers))
            {
                int lineCounter = 1;
                string str = readFile.ReadLine();
                while (str != null)
                {
                    writeNewFile.WriteLine("{0} - {1}", lineCounter, str);
                    str = readFile.ReadLine();
                    lineCounter++;
                }
            }
        }
        Console.WriteLine("Job is DONE!");
    }
}