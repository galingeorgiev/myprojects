/* Define classes File { string name, int size } and Folder 
 * { string name, File[] files, Folder[] childFolders } and 
 * using them build a tree keeping all files and folders on 
 * the hard drive starting from C:\WINDOWS. Implement a method 
 * that calculates the sum of the file sizes in given subtree
 * of the tree and test it accordingly. Use recursive DFS traversal.
 */

namespace FileSystemTree
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;

    public class FileSystemTree
    {
        public static StringCollection log = new StringCollection();
        public static Dictionary<string, Folder> windowsDirectory = new Dictionary<string, Folder>();

        public static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
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
                    CreateTree(fi);
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }
        }

        public static void CreateTree(FileInfo file)
        {
            string path = file.FullName;
            path = path.Substring(2, path.Length - 2);
            string[] folders = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string fileFolder = folders[folders.Length - 2];
            
            for (int i = 0; i < folders.Length - 1; i++)
            {
                Folder currentFolder = new Folder();
                currentFolder.Name = folders[i];

                if (!windowsDirectory.ContainsKey(folders[i]))
                {
                    windowsDirectory.Add(folders[i], currentFolder);
                }
                else
                {
                    if (!windowsDirectory[folders[i]].ChildFolders.Contains(currentFolder))
                    {
                        windowsDirectory[folders[i]].AddSubFolder(currentFolder);
                    }
                }
            }

            File currentFile = new File();
            currentFile.Name = file.Name;
            currentFile.Size = file.Length;

            windowsDirectory[fileFolder].Files.Add(currentFile);
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

            // You can stop on line below and see results in variable 'windowsDirectory'.
            // I can not find good way to print all information and printing is slow in all case.
            Console.WriteLine();
        }
    }
}