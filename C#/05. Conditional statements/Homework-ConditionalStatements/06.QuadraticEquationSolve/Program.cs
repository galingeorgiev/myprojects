using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.QuadraticEquationSolve
{
    class Program
    {
        static double NumberValidetion(string n)
        {
            double firstNumber = 0;
            while (double.TryParse(n, out firstNumber) == false)
            {
                Console.WriteLine("Please enter valid value.\nYou can check you culture!");
                Console.Write("Please enter corect value = ");
                n = Console.ReadLine();
            }
            return firstNumber;
        }
        static double CalculateDiscriminanta(double a, double b, double c)
        {
            double d = (b * b) - (4 * a * c);
            return d;
        }
        static void CalculateRealRoots(double a, double b, double c, double d)
        {
            if (d < 0)
            {
                Console.WriteLine("There isn't real roots");
            }
            else
            {
                if (d == 0)
                {
                    double equationAnswar = -(b / (2 * a));
                    Console.WriteLine("Answar is: X1=X2={0:0.###}", equationAnswar);
                }
                else
                {
                    double equationAnswar1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double equationAnswer2 = (-b - Math.Sqrt(d)) / (2 * a);
                    Console.WriteLine("Answar is: X1={0:0.###} and X2={1:0.###}", equationAnswar1, equationAnswer2);
                }
            }
        }
        static void Main()
        {
            Console.Write("Please enter value for a: ");
            string stringA = Console.ReadLine();
            double a = NumberValidetion(stringA);

            Console.Write("Please enter value for b: ");
            string stringB = Console.ReadLine();
            double b = NumberValidetion(stringB);

            Console.Write("Please enter value for c: ");
            string stringC = Console.ReadLine();
            double c = NumberValidetion(stringC);

            double d = CalculateDiscriminanta(a, b, c);
            Console.WriteLine("Discriminanta is: {0}", d);
            CalculateRealRoots(a, b, c, d);
        }
    }
}
