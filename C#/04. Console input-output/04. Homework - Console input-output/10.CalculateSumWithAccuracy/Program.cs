using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CalculateSumWithAccuracy
{
    class Program
    {
        static void Main()
        {
            double old = 0;
            double temp = 1;
            double i = 1;
            while ((temp - old) >= 0.001)
            {
                i++;
                //double i = 1;
                //i = i + 1;
                old = temp;
                temp = old + (1 / i);
            }
            Console.WriteLine("Result of sum is: {0:#.000}", temp);
        }
    }
}
