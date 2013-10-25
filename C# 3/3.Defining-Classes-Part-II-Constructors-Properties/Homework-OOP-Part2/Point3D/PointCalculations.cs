/*Write a static class with a static method to calculate
 *the distance between two points in the 3D space.*/

using System;

namespace Point3D
{
    static class PointCalculations
    {
        //Define methods
        public static double Point3DDistance(Point3D firstPoint, Point3D secondPoint)
        {
            //Euclidean distance
            double distance = Math.Sqrt(
                ((firstPoint.X - secondPoint.X)*(firstPoint.X - secondPoint.X))+
                ((firstPoint.Y - secondPoint.Y)*(firstPoint.Y - secondPoint.Y))+
                ((firstPoint.Z - secondPoint.Z)*(firstPoint.Z - secondPoint.Z)));

            return distance;
        }
    }
}
