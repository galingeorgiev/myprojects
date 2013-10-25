using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left, j = right;
        IComparable pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                IComparable tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        if (left < j)
        {
            Quicksort(elements, left, j);
        }

        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }

    static void Main()
    {
        string input = @"../../UsingFiles/Input.txt";
        string output = @"../../UsingFiles/Output.txt";

        FileStream inputFile = new FileStream(input, FileMode.Create);
        inputFile.Dispose();

        FileStream outputFile = new FileStream(output, FileMode.Create);
        outputFile.Dispose();

        using (StreamWriter writeInputFile = new StreamWriter(input, false))
        {
            writeInputFile.WriteLine("Ivan");
            writeInputFile.WriteLine("Peter");
            writeInputFile.WriteLine("Maria");
            writeInputFile.WriteLine("George");
        }

        List<string> fileContent = new List<string>();

        using (StreamReader readContent = new StreamReader(input))
        {
            string line = readContent.ReadLine();

            while (line != null)
            {
                fileContent.Add(line);
                line = readContent.ReadLine();
            }
        }

        string[] fileContentArray = fileContent.ToArray();

        Quicksort(fileContentArray, 0, fileContentArray.Length - 1);

        using (StreamWriter writeOutputFile = new StreamWriter(output))
        {
            for (int i = 0; i < fileContentArray.Length; i++)
            {
                writeOutputFile.WriteLine(fileContentArray[i]);
            }
        }
        Console.WriteLine("Job is DONE!");
    }
}