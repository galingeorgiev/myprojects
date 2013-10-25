using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PrintSquareFromNumbers
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter value for N in range [2-19]: ");
            int n = int.Parse(Console.ReadLine());
            if (n > 1 & n < 20)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = i; j < n + i; j++)
                    {
                        Console.Write("{0,3}", j);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You enter incorect value!\nPlease try agane.");
            }
        }
    }
}
