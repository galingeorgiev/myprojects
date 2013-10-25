/*Create a structure Point3D to hold a 3D-coordinate
 *{X, Y, Z} in the Euclidian 3D space. Implement the
 *ToString() to enable printing a 3D point.*/

using System;

namespace Point3D
{
    struct Point3D
    {
        private int x;
        private int y;
        private int z;

        /*Add a private static read-only field to hold the start
         *of the coordinate system – the point O{0, 0, 0}.*/
        private static readonly Point3D point0 = new Point3D(0, 0, 0);

        //Define Constructor
        public Point3D(int x, int y, int z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Define Properties
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public int Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public override string ToString()
        {
            return string.Format("x = {0}, y = {1}, z = {2}", this.x, this.y, this.z);
        }

        // Add a static property to return the pointO.
        public static Point3D Point0
        {
            get { return point0; }
        }
    }
}
