using System;

namespace CohesionAndCoupling
{
    public class DistanceCalculation
    {
        private static double width;
        private static double height;
        private static double depth;

        public static double Width
        {
            get 
            {
                return DistanceCalculation.width; 
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width sould be bigger from zero.");
                }

                DistanceCalculation.width = value; 
            }
        }

        public static double Height
        {
            get 
            {
                return DistanceCalculation.height; 
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height sould be bigger from zero.");
                }

                DistanceCalculation.height = value; 
            }
        }
        
        public static double Depth
        {
            get 
            {
                return DistanceCalculation.depth; 
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Depth sould be bigger from zero.");
                }

                DistanceCalculation.depth = value; 
            }
        }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
            return distance;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
