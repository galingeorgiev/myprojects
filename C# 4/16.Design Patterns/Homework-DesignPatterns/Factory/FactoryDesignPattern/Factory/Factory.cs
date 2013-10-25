/* Code for example.
 * This code is from: http://en.wikipedia.org/wiki/Factory_method_pattern
 * I only correct some warnings.
 * Classes not separeted in different files for better readability. */

namespace Factory
{
    using System;

    public class Complex
    {
        public double real;
        public double imaginary;

        public static Complex FromCartesianFactory(double real, double imaginary)
        {
            return new Complex(real, imaginary);
        }

        public static Complex FromPolarFactory(double modulus, double angle)
        {
            return new Complex(modulus * Math.Cos(angle), modulus * Math.Sin(angle));
        }

        private Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
    }

    class Program
    {
        static void Main()
        {
            Complex product = Complex.FromPolarFactory(1, Math.PI);
        }
    }
}
