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
        string tempFile = @"../../UsingFiles/Temp.txt";

        FileStream fs = new FileStream(input, FileMode.Create);
        fs.Dispose();

        FileStream fsTemp = new FileStream(tempFile, FileMode.Create);
        fsTemp.Dispose();

        using (StreamWriter writeContent = new StreamWriter(input, false))
        {
            writeContent.WriteLine("Line 1");
            writeContent.WriteLine("Line 2");
            writeContent.WriteLine("Line 3");
            writeContent.WriteLine("Line 4");
            writeContent.WriteLine("Line 5");
            writeContent.WriteLine("Line 6");
            writeContent.WriteLine("Line 7");
        }

        using (StreamReader readContent = new StreamReader(input))
        {
            string lineContent = readContent.ReadLine();
            int countLine = 0;
            using (StreamWriter writeNewContent = new StreamWriter(tempFile,false))
            {
                while (lineContent != null)
                {
                    if (countLine % 2 != 0)
                    {
                        writeNewContent.WriteLine(lineContent);
                    }
                    countLine++;
                    lineContent = readContent.ReadLine();
                }
            }
        }

        File.Delete(input);
        File.Move(tempFile, input);
        Console.WriteLine("Job is DONE!");
    }
}
