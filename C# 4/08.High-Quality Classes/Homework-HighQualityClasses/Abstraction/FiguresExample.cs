using System;

/* Take the VS solution "Abstraction" and refactor its code to provide good abstraction.
 * Move the properties and methods from the class Figure to their correct place.
 * Move the common methods to the base class's interface. Remove all duplicated code (properties / methods / other code).
 * Establish good encapsulation in the classes from the VS solution "Abstraction".
 * Ensure that incorrect values cannot be assigned in the internal state of the classes. */

namespace Abstraction
{
    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            double circlePerimeter = circle.CalcPerimeter();
            double circleSurface = circle.CalcSurface();
            Console.WriteLine(
                "I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.",
                circlePerimeter,
                circleSurface);

            Rectangle rect = new Rectangle(2, 3);
            double rectanglePerimeter = rect.CalcPerimeter();
            double rectangleSurface = rect.CalcSurface();
            Console.WriteLine(
                "I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.",
                rectanglePerimeter,
                rectangleSurface);
        }
    }
}
