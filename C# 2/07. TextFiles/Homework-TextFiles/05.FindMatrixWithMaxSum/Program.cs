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
        string output = @"../../UsingFiles/Output.txt";

        FileStream inputFile = new FileStream(input, FileMode.Create);
        inputFile.Dispose();

        FileStream outputFile = new FileStream(output, FileMode.Create);
        outputFile.Dispose();

        using (StreamWriter writeInputFile = new StreamWriter(input,false))
        {
            writeInputFile.WriteLine("4");
            writeInputFile.WriteLine("2 3 3 4");
            writeInputFile.WriteLine("0 2 3 4");
            writeInputFile.WriteLine("3 7 1 2");
            writeInputFile.WriteLine("4 3 3 2");
        }

        using (StreamReader readInputFile = new StreamReader(input))
        {
            string sizeOfMatrix = readInputFile.ReadLine();
            int n = int.Parse(sizeOfMatrix);
            int[,] matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                string line = readInputFile.ReadLine();
                string[] lines = line.Split(' ');

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(lines[j]);
                }
            }

            int bestSum = int.MinValue;

            for (int i = 0; i < n - 1; i++)
            {
                int tempSum = 0;
                for (int j = 0; j < n - 1; j++)
                {
                    tempSum = matrix[i,j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (tempSum > bestSum)
                    {
                        bestSum = tempSum;
                    }
                }
            }

            using (StreamWriter writeResult = new StreamWriter(output,false))
            {
                writeResult.WriteLine(bestSum);
            }
        }
        Console.WriteLine("Job is DONE!");
    }
}