using System;

namespace CohesionAndCoupling
{
    public static class FigureGeometry
    {
        private static double width;
        private static double height;
        private static double depth;

        public static double Width
        {
            get
            {
                return FigureGeometry.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width sould be bigger from zero.");
                }

                FigureGeometry.width = value;
            }
        }

        public static double Height
        {
            get
            {
                return FigureGeometry.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height sould be bigger from zero.");
                }

                FigureGeometry.height = value;
            }
        }

        public static double Depth
        {
            get
            {
                return FigureGeometry.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Depth sould be bigger from zero.");
                }

                FigureGeometry.depth = value;
            }
        }

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }
    }
}
