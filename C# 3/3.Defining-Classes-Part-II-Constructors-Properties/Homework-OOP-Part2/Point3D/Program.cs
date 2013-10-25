using System;
using System.Collections.Generic;

namespace Point3D
{
    class Program
    {
        static void Main()
        {
            //Create new point
            Point3D myPoint = new Point3D(2, 3, 4);
            Console.WriteLine(myPoint);
            Console.WriteLine(Point3D.Point0);

            //Calculate distance between two points
            double distance = PointCalculations.Point3DDistance(Point3D.Point0, myPoint);
            Console.WriteLine(distance);

            //Create new path and add elements
            Path testPath = new Path(myPoint);
            testPath.AddToPath(Point3D.Point0);

            //Save path in file
            PathStorage.SaveInFile(testPath);

            //Create new path and add points from file
            Path readTest = new Path();
            readTest = PathStorage.ReadFromFile();
            //Print readed from file points
            List<Point3D> points = new List<Point3D>();
            points = readTest.GetAllPathElements();
            foreach (var item in points)
            {
                Console.WriteLine(item);
            }
        }
    }
}
