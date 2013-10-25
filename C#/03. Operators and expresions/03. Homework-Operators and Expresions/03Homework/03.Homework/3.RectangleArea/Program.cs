using System;

namespace _3.RectangleArea
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter rectangle width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Please enter rectangle height: ");
            double height = double.Parse(Console.ReadLine());

            double rectangleArea = width * height;
            Console.WriteLine("Rectangle area is: {0}", rectangleArea);
        }
    }
}
