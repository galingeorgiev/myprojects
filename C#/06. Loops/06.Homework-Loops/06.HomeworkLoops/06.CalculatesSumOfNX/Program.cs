using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _06.CalculatesSumOfNX
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter value for n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter value for x: ");
            int x = int.Parse(Console.ReadLine());

            decimal sum = 0;
            int factoriel = 1;
            decimal divider = 1;
            for (int i = 0; i < n; i++)
            {
                factoriel = factoriel * (i +1);
                divider = (decimal) Math.Pow(x,i);
                sum = sum + (factoriel/divider);
            }
            Console.WriteLine("Result is: {0}", sum);
        }
    }
}
