/* Algo Academy February 2013 – Problem 04 – Salaries */

namespace Salaries
{
    using System;
    using System.Linq;

    public class Salaries
    {
        public static void Main()
        {
            int c = int.Parse(Console.ReadLine());
            long[] employeeSalary = new long[c];
            string[] conections = new string[c];

            for (int i = 0; i < c; i++)
            {
                string currentLine = Console.ReadLine();
                conections[i] = currentLine;
            }

            string emptyEmp = new string('N', c);

            for (int i = 0; i < c; i++)
            {
                if (conections[i] == emptyEmp)
                {
                    employeeSalary[i] = 1;
                }
            }

            bool isArrayFull = false;

            while (!isArrayFull)
            {
                bool hasMissingSalary = false;

                for (int i = 0; i < c; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        if (conections[i][j] == 'Y' && employeeSalary[j] == 0)
                        {
                            hasMissingSalary = true;
                            break;
                        }
                    }

                    if (!hasMissingSalary && employeeSalary[i] == 0)
                    {
                        for (int z = 0; z < c; z++)
                        {
                            if (conections[i][z] == 'Y')
                            {
                                employeeSalary[i] = employeeSalary[i] + employeeSalary[z];
                            }
                        }
                    }

                    hasMissingSalary = false;
                }

                isArrayFull = true;
                for (int v = 0; v < c; v++)
                {
                    if (employeeSalary[v] == 0)
                    {
                        isArrayFull = false;
                        break;
                    }
                }
            }

            long result = employeeSalary.Sum();
            Console.WriteLine(result);
        }
    }
}
