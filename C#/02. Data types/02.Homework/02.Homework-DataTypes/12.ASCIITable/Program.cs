using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ASCIITable
{
    class Program
    {
        static void Main()
        {
            Encoding fileEncoding = Encoding.ASCII;
            char asciiSymbols;
            for (int counter = 0; counter < 128; counter++)
            {
                asciiSymbols = (char)counter;
                string printedASCII = null;
                if (char.IsWhiteSpace(asciiSymbols))
                {
                    switch (asciiSymbols)
                    {
                        case '\n':
                        printedASCII = "\\n";
                        break;

                        case '\t':
                        printedASCII = "\\t";
                        break;

                        case '\r':
                        printedASCII = "\\r";
                        break;

                        case '\v':
                        printedASCII = "\\v";
                        break;

                        case '\f':
                        printedASCII = "\\f";
                        break;

                        case ' ':
                        printedASCII = "space";
                        break;
                    }
                }
                else if (char.IsControl(asciiSymbols))
                {
                    printedASCII = "control";
                }
                else
                {
                    printedASCII = asciiSymbols.ToString();
                }
                Console.WriteLine("Decimal value: {0}   Hexadecimal value: {1:x}    ASCII Symbol: {2}",
                    counter,counter,printedASCII);
            }
        }
    }
}
