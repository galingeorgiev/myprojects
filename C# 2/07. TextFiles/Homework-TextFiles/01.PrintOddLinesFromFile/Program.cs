using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static void Main()
    {
        //Create text file
        string filePath = @"../../UsingFiles/01.ReadOddLines.txt";
        FileStream fs = new FileStream(filePath, FileMode.Create);
        fs.Dispose();

        //Write text in file
        using (StreamWriter write = new StreamWriter(filePath,false,Encoding.GetEncoding("Windows-1251")))
        {
            for (int i = 0; i < 20; i++)
            {
                write.WriteLine("Line {0}", i);
            }
        }

        //Read text
        using (StreamReader read = new StreamReader(filePath))
        {
            string line = read.ReadLine();
            int lineCounter = 0;

            while (line != null)
            {
                if (lineCounter % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                line = read.ReadLine();
                lineCounter++;
            }
        }
    }
}