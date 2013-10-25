using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.TrapexeArea
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter value for a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Please enter value for b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Please enter value for h: ");
            double h = double.Parse(Console.ReadLine());

            double trapezeArea = ((a + b) / 2) * h;
            Console.WriteLine("Area of trapeze is: {0}", trapezeArea);
        }
    }
}
