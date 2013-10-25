using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NumbersFrom1toN
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i != n)
                {
                    Console.Write("{0}, ", i);
                }
                else
                {
                    Console.Write("{0}", i);
                }
            }
            Console.WriteLine();
        }
    }
}
