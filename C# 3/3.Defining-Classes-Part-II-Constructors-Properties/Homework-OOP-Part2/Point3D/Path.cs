//Create a class Path to hold a sequence of points in the 3D space.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Point3D
{
    class Path
    {
        private List<Point3D> newPath = new List<Point3D>();

        //Define constructors
        public Path()
        {
        }

        public Path(Point3D point3D)
        {
            newPath.Add(point3D);
        }

        //Define method
        public List<Point3D> GetAllPathElements()
        {
            return this.newPath;
        }

        public void AddToPath(Point3D point3D)
        {
            this.newPath.Add(point3D);
        }
    }
}
