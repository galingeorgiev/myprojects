using System;
using System.IO;
using System.Text.RegularExpressions;
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
            writeContent.WriteLine("testing my program");
            writeContent.WriteLine("My program is in testing period");
            writeContent.WriteLine("text testsssss text");
            writeContent.WriteLine("other test here");
        }

        using (StreamReader readFile = new StreamReader(input))
        {
            string line = readFile.ReadLine();
            using (StreamWriter writeFile = new StreamWriter(tempFile, false))
            {
                while (line != null)
                {
                    string newLine = Regex.Replace(line, @"(?<!\w)test\w+", "");
                    writeFile.WriteLine(newLine);
                    line = readFile.ReadLine();
                }
            }
        }

        File.Delete(input);
        File.Move(tempFile, input);
        Console.WriteLine("Job is DONE!");
    }
}