/* Write a program to traverse the directory C:\WINDOWS and all its 
 * subdirectories recursively and to display all files matching the 
 * mask *.exe. Use the class System.IO.Directory.
 */

namespace TraverseWindowsDirectory
{
    using System;
    using System.Collections.Specialized;
    using System.IO;

    public class TraverseWindowsDirectory
    {
        public static StringCollection log = new StringCollection();

        public static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
 
            try
            {
                files = root.GetFiles("*.exe");
            }
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }
        }

        public static void Main()
        {
            DirectoryInfo myWindowsDirectory = new DirectoryInfo(@"c:\Windows\");
            WalkDirectoryTree(myWindowsDirectory);

            // Write out all the files that could not be processed.
            Console.WriteLine("Files with restricted access:");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }
        }
    }
}