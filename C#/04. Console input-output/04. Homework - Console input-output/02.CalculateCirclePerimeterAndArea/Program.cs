using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CalculateCirclePerimeterAndArea
{
    class Program
    {
        static double NumberValidetion(string n)
        {
            double firstNumber = 0;
            while (double.TryParse(n, out firstNumber) == false)
            {
                Console.WriteLine("You enter incorect value.\nPlease check you culture!");
                Console.Write("Please enter corect value = ");
                n = Console.ReadLine();
            }
            return firstNumber;
        }

        static void Main()
        {
            Console.Write("Please enter radius (m) R = ");
            string stringRadius = Console.ReadLine();
            double radius = NumberValidetion(stringRadius);
            double area = Math.PI * radius * radius;
            double perimeter = 2 * radius * Math.PI;
            Console.WriteLine("Area of circle is: {0:0.#####}",area);
            Console.Write("Perimeter of circle is: {0:0.#####}\n",perimeter);

        }
    }
}
