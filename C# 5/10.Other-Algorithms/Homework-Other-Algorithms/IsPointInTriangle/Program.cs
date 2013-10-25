/* You are given 3 points A, B and C, forming triangle, 
 * and a point P. Check if the point P is in the triangle or not.
 * 
 *        Y
 *        ^
 *        |                   6,4
 *        |                   /\
 *        |                  /  \
 *        |                 /    \
 *        |                /      \
 *        |               /        \
 *        |              /          \
 *        |             /            \
 *        |            /              \
 *        |           /                \
 *        |          /                  \ 
 *        |         /                    \
 *        |        /                      \
 *        |       /                        \
 *        |      /                          \
 *        |     /             4,2            \ 7,2
 *        |    1,1---------------------------7,1
 *        |-------------------------------------------------> X
 */

namespace IsPointInTriangle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Point firstPoint = new Point(1, 1);
            Point secondPoint = new Point(7, 1);
            Point thirdPoint = new Point(4, 6);
            Point pointInTriangle = new Point(4, 2);
            Point pointOutOfTriangle = new Point(7, 2);

            bool pointIsInTriangle = Point.IsPointInTriangle(pointInTriangle, firstPoint, secondPoint, thirdPoint);
            Console.WriteLine("Is point in triangle: {0}", pointIsInTriangle);

            bool pointIsOutOfTriangle = Point.IsPointInTriangle(pointOutOfTriangle, firstPoint, secondPoint, thirdPoint);
            Console.WriteLine("Is point in triangle: {0}", pointIsOutOfTriangle);
        }
    }
}
