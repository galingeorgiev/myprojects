/* Define two new classes Triangle and Rectangle that implement
 * the virtual method and return the surface of the figure
 * (height*width for rectangle and height*width/2 for triangle).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface(double width, double height)
        {
            return (width * height) / 2;
        }
    }
}
