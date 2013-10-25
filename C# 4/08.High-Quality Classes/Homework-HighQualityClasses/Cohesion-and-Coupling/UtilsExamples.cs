using System;

/* Take the VS solution "Cohesion-and-Coupling" and refactor its code to follow the principles
 * of good abstraction, loose coupling and strong cohesion. Split the class Utils to other
 * classes that have strong cohesion and are loosely coupled internally. */

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        public static void Main()
        {
            // Uncomment line below and you can see that this will throw exception
            // because file name is incorrect and doesn't contain file extension.
            // Console.WriteLine(FileExtensions.GetFileExtension("example"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceCalculation.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceCalculation.CalcDistance3D(5, 2, -1, 3, -6, 4));

            FigureGeometry.Width = 3;
            FigureGeometry.Height = 4;
            FigureGeometry.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", FigureGeometry.CalcVolume());

            DistanceCalculation.Width = 3;
            DistanceCalculation.Height = 4;
            DistanceCalculation.Depth = 5;
            Console.WriteLine("Diagonal XYZ = {0:f2}", DistanceCalculation.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", DistanceCalculation.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", DistanceCalculation.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", DistanceCalculation.CalcDiagonalYZ());
        }
    }
}
