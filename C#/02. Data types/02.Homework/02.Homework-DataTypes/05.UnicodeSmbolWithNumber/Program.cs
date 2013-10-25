using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.UnicodeSmbolWithNumber
{
    class Program
    {
        static void Main()
        {
            char unicodeSymbol = (char)72;
            Console.WriteLine("\u0048 is same as {0}", unicodeSymbol);
        }
    }
}
