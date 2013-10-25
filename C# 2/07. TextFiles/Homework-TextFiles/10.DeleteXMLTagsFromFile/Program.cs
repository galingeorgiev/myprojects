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
            writeContent.WriteLine(@"<?xml version=""1.0""><student><name>Pesho</name>");
            writeContent.WriteLine(@"<age>21</age><interests count=""3""><interest> ");
            writeContent.WriteLine("Games</instrest><interest>C#</instrest><interest>");
            writeContent.WriteLine("Java</instrest></interests></student>");
        }

        using (StreamReader readFile = new StreamReader(input))
        {
            string line = readFile.ReadLine();
            using (StreamWriter writeFile = new StreamWriter(tempFile,false))
            {
                while (line != null)
                {
                    string newLine = Regex.Replace(line, "<[^>]*>", "\n\r");
                    newLine = Regex.Replace(newLine, @"^\s+$[\r\n]*", " ", RegexOptions.Multiline);
                    writeFile.WriteLine(newLine.Trim());
                    line = readFile.ReadLine();
                }
            }
        }

        File.Delete(input);
        File.Move(tempFile, input);
        Console.WriteLine("Job is DONE!");
    }
}