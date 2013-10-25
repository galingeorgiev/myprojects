using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.InCircleAndRectangle
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter 'X' coordinate of point 'O': ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Please enter 'Y' coordinate of point 'O': ");
            double y = double.Parse(Console.ReadLine());

            double xyToSquare = x * x + y * y;
            double rezult = Math.Sqrt(xyToSquare);

            bool inRectangleX = x >= -1 & x <= 5;
            bool inRectangleY = y >= 1 & y <= 2;
            bool inRectangle = inRectangleX & inRectangleY;

            if (rezult < 5 & inRectangle)
            {
                Console.WriteLine("The point 'O' is in circle and rectangle.");
            }
            else
            {
                Console.WriteLine("The point 'O' is out of circle and rectangle.");
            }
        }
    }
}
