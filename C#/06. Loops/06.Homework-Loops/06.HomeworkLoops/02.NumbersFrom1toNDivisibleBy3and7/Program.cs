using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NumbersFrom1toNDivisibleBy3and7
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 | i % 7 != 0)
                {
                    Console.WriteLine("{0}", i);
                }
            }
        }
    }
}
