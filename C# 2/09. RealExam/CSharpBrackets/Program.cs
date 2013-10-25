using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<string> inputLines = new List<string>();
        List<string> resultLines = new List<string>();
        StringBuilder resultCode = new StringBuilder();

        int numberOfLines = int.Parse(Console.ReadLine());
        string tabSymbol = Console.ReadLine();

        for (int i = 0; i < numberOfLines; i++)
        {
            string tempLine = Console.ReadLine();

            if (!string.IsNullOrEmpty(tempLine))
            {
                inputLines.Add(tempLine);
            }
        }

        int tabIn = 0;
        bool isNewLine = true;
        for (int i = 0; i < inputLines.Count; i++)
        {
            for (int j = 0; j < inputLines[i].Length; j++)
            {
                char currentSymbol = inputLines[i][j];

                if (currentSymbol == ' ')
                {
                    if (j != inputLines[i].Length - 1)
                    {
                        if (inputLines[i][j + 1] == ' ')
                        {
                            continue;
                        }
                    }

                    if (j != 0)
                    {
                        if (inputLines[i][j - 1] == '{')
                        {
                            continue;
                        }
                    }

                    if (j != inputLines[i].Length - 1)
                    {
                        if (inputLines[i][j + 1] == '}')
                        {
                            continue;
                        }
                    }
                }

                if (currentSymbol == '{')
                {
                    if (j != 0)
                    {
                        resultCode.Append(Environment.NewLine);
                    }
                    //resultCode.Append(Environment.NewLine);
                    resultCode.Append(string.Concat(Enumerable.Repeat(tabSymbol, tabIn)));
                    resultCode.Append("{");
                    //resultCode.Append(Environment.NewLine);
                    tabIn++;
                    if ( j != inputLines[i].Length - 1)
                    {
                        resultCode.Append(Environment.NewLine);
                        resultCode.Append(string.Concat(Enumerable.Repeat(tabSymbol, tabIn)));
                        isNewLine = false;
                    }
                    //resultCode.Append(string.Concat(Enumerable.Repeat(tabSymbol, tabIn)));
                    continue;
                }
                isNewLine = true;
                if (currentSymbol == '}')
                {
                    tabIn--;
                    if (j != 0)
                    {
                        resultCode.Append(Environment.NewLine);
                    }
                    //resultCode.Append(Environment.NewLine);
                    resultCode.Append(string.Concat(Enumerable.Repeat(tabSymbol, tabIn)));
                    resultCode.Append("}");
                    //isNewLine = false;
                    if (j != inputLines[i].Length - 1)
                    {
                        resultCode.Append(Environment.NewLine);
                    }
                    
                    continue;
                }

                if (currentSymbol == ';')
                {
                    resultCode.Append(string.Concat(Enumerable.Repeat(tabSymbol, tabIn)));
                    resultCode.Append(currentSymbol);
                    continue;
                }

                resultCode.Append(currentSymbol);
            }
            resultCode.Append(Environment.NewLine);
            if (i != inputLines.Count - 2 & isNewLine)
            {
                resultCode.Append(string.Concat(Enumerable.Repeat(tabSymbol, tabIn)));
            }
            //resultCode.Append(string.Concat(Enumerable.Repeat(tabSymbol, tabIn)));
            //resultLines.Add(resultCode.ToString());
            //resultCode.Clear();
        }

        //var newresultCode = Regex.Replace(resultCode.ToString(), @"\n\s*\n", @"\n", RegexOptions.Multiline);
        Console.WriteLine(resultCode);
        //foreach (var item in resultLines)
        //{
        //    if (!string.IsNullOrEmpty(item))
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
    }
}
