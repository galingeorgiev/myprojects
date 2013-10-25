/*Create a static class PathStorage with static methodsto save
 *and load paths from a text file. Use a file format of your choice.*/

using System;
using System.IO;
using System.Collections.Generic;

namespace Point3D
{
    static class PathStorage
    {
        //Define methods
        public static void SaveInFile(Path path)
        {
            string filePath = @"../../UsingFiles/SavedPathOfPoints.txt";
            FileStream fs = new FileStream(filePath, FileMode.Create);
            fs.Dispose();

            using (StreamWriter writeFile = new StreamWriter(filePath, false))
            {
                List<Point3D> tempList = new List<Point3D>();
                tempList = path.GetAllPathElements();

                foreach (var point in tempList)
                {
                    writeFile.WriteLine(point);
                }
            }
        }

        /// <summary>
        /// Elements in file must be in format x y z
        /// New point is in new line
        /// </summary>
        /// <returns>Return Path</returns>
        public static Path ReadFromFile()
        {
            Path readedPath = new Path();
            string filePath = @"../../UsingFiles/TestRead.txt";
            using(StreamReader readFile = new StreamReader(filePath))
            {
                string line = readFile.ReadLine();
                while (line != null)
                {
                    List<string> xyz = new List<string>(line.Split(' '));
                    Point3D tempPoint3D = new Point3D();
                    tempPoint3D.X = int.Parse(xyz[0]);
                    tempPoint3D.Y = int.Parse(xyz[1]);
                    tempPoint3D.Z = int.Parse(xyz[2]);
                    readedPath.AddToPath(tempPoint3D);
                    line = readFile.ReadLine();
                }
                Console.WriteLine("Job is DONE!");
            }
            return readedPath;
        }
    }
}
