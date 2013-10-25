/* Define class Circle and suitable constructor so that at
 * initialization height must be kept equal to width and
 * implement the CalculateSurface() method.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class Circle : Shape
    {
        public Circle(double diameter)
            : base(diameter, diameter)
        {
        }

        public override double CalculateSurface(double diametar, double height = 0)
        {
            return Math.PI * (diametar / 2) * (diametar / 2);
        }
    }
}
