/*Define abstract class Shape with only one abstract
 *method CalculateSurface() and fields width and height.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public abstract class Shape
    {
        private double width;
        private double height;

        public double Width
        {
            get { return this.width; }
        }

        public double Height
        {
            get { return this.height; }
        }

        public Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public abstract double CalculateSurface(double width, double height);
    }
}
