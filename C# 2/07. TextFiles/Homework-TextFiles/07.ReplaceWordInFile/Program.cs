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

        using (StreamWriter writeContent = new StreamWriter(input,false))
        {
            writeContent.WriteLine("Only start");
            writeContent.WriteLine("start from here");
            writeContent.WriteLine("Some text start from here");
            writeContent.WriteLine("Other content with word start");
            writeContent.WriteLine("Just starting");
            writeContent.WriteLine("start start start");
        }

        using (StreamReader readContent = new StreamReader(input))
        {
            string line = readContent.ReadLine();

            using (StreamWriter writeNewContent = new StreamWriter(tempFile,false))
            {
                while (line != null)
                {
                    string temp = line.Replace("start", "finish");
                    writeNewContent.WriteLine(temp);
                    line = readContent.ReadLine();
                }
            }
        }

        File.Delete(input);
        File.Move(tempFile, input);
        Console.WriteLine("Job is DONE!");
    }
}
