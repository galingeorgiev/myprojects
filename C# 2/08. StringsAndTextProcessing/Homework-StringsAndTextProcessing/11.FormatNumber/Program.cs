using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("{0,15:d}", number);
        Console.WriteLine("{0,15:x}", number);
        Console.WriteLine("{0,15:p}", number);
        Console.WriteLine("{0,15:e}", number);
    }
}