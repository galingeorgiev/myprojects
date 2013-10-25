using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.InOrOutOfCircle
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter'X' coordinate of point 'O': ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Please enter'Y' coordinate of point 'O': ");
            double y = double.Parse(Console.ReadLine());

            double xyToSquare = x * x + y * y;
            double rezult = Math.Sqrt(xyToSquare);

            if (rezult > 5)
            {
                Console.WriteLine("The point 'O' is out of circle.");
            }
            else
            {
                if (rezult < 5)
                {
                    Console.WriteLine("The point 'O' is in circle.");
                }
                else
                {
                    Console.WriteLine("The point 'O' is on circle.");
                }
            }
        }
    }
}
