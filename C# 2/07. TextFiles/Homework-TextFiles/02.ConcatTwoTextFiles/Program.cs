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
        //Create text file
        string filePath = @"../../UsingFiles/02.ConcatedFile.txt";
        FileStream fs = new FileStream(filePath, FileMode.Create);
        fs.Dispose();
        //Create other two files
        string filePathFirst = @"../../UsingFiles/02.FirstFile.txt";
        FileStream firstFile = new FileStream(filePathFirst, FileMode.Create);
        firstFile.Dispose();
        string filePathSecond = @"../../UsingFiles/02.SecondFile.txt";
        FileStream secondFile = new FileStream(filePathSecond, FileMode.Create);
        secondFile.Dispose();

        using (StreamWriter writeFirstFile = new StreamWriter(filePathFirst,false))
        {
            for (int i = 0; i < 10; i++)
            {
                writeFirstFile.WriteLine("Text file 1, line {0}", i);
            }
        }

        using (StreamWriter writeSecondFile = new StreamWriter(filePathSecond,false))
        {
            for (int i = 0; i < 10; i++)
            {
                writeSecondFile.WriteLine("Text file 2, line {0}", i);
            }
        }

        using (StreamWriter concatFile = new StreamWriter(filePath,false))
        {
            using (StreamReader readFirstFile = new StreamReader(filePathFirst))
            {
                string firstFileStr = readFirstFile.ReadLine();
                while (firstFileStr != null)
                {
                    concatFile.WriteLine(firstFileStr);
                    firstFileStr = readFirstFile.ReadLine();
                }
            }

            using (StreamReader readSecondFile = new StreamReader(filePathSecond))
            {
                string secondFileStr = readSecondFile.ReadLine();
                while (secondFileStr != null)
                {
                    concatFile.WriteLine(secondFileStr);
                    secondFileStr = readSecondFile.ReadLine();
                }
            }
        }
        Console.WriteLine("Job is DONE!");
    }
}