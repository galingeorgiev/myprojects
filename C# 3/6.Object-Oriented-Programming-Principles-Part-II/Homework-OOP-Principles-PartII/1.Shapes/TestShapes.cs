/* Define abstract class Shape with only one abstract method CalculateSurface()
 * and fields width and height. Define two new classes Triangle and Rectangle
 * that implement the virtual method and return the surface of the figure
 * (height*width for rectangle and height*width/2 for triangle). Define class
 * Circle and suitable constructor so that at initialization height must be
 * kept equal to width and implement the CalculateSurface() method.
 * ------------------------------------------------------------------------------
 * Write a program that tests the behavior of  the CalculateSurface() method for
 * different shapes (Circle, Rectangle, Triangle) stored in an array. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class TestShapes
    {
        static void Main()
        {
            //Create array of shapes
            Shape[] shapesArr = new Shape[] {
            new Triangle(4,2),
            new Rectangle(2.5 , 3.5),
            new Circle(2.2)};

            //Print shape name and surface
            foreach (var shape in shapesArr)
            {
                Console.WriteLine("{0} surface is {1:f2}",shape.GetType().Name, shape.CalculateSurface(shape.Width, shape.Height));
            }
        }
    }
}
