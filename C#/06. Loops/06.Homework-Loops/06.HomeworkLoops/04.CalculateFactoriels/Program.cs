using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.CalculateFactoriels
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value for N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter value for K: ");
            int k = int.Parse(Console.ReadLine());
            int result = 1;
            for (int i = n + 1; i <= k; i++)
            {
                result = result * i;
            }
            double finalResult = (1.0 / result);
            Console.WriteLine("{0:0.###########}", finalResult);
        }
    }
}
