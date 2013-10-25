using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _07.FibonacciSequence
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            BigInteger a = 0;
            BigInteger b = 0;
            BigInteger temp = 1;
            BigInteger result = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(a);
                }
                b = temp;
                temp = result;
                result = temp + b;
                Console.WriteLine(result);
            }
        }
    }
}
