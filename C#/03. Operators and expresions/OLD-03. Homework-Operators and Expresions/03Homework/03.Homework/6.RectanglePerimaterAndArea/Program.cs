using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.RectanglePerimaterAndArea
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter value for a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Please enter value for b: ");
            double b = double.Parse(Console.ReadLine());

            double rectanglePerimeetr = (a + b) * 2;
            double rectangleArea = a * b;
            Console.WriteLine("Area of rectangle is: {0}\nPerimeter is {1}", rectangleArea, rectanglePerimeetr);
        }
    }
}
