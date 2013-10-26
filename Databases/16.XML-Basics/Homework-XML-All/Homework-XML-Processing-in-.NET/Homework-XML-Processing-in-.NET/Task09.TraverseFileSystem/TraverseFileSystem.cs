/* Write a program to traverse given directory and write
 * to a XML file its contents together with all subdirectories
 * and files. Use tags <file> and <dir> with appropriate 
 * attributes. For the generation of the XML document use the
 * class XmlWriter.
 */

namespace Task09.TraverseFileSystem
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class TraverseFileSystem
    {
        static void Main()
        {
            string rootPath = @"C:\Windows\Help\Windows";
            var dir = new DirectoryInfo(rootPath);

            var doc = new XDocument(GetDirectoryXml(dir));

            string fileName = "../../Directoies.xml";
            doc.Save(fileName);
            Console.WriteLine("File Directories.xml created!");
        }

        public static XElement GetDirectoryXml(DirectoryInfo dir)
        {
            var info = new XElement("dir",
                           new XAttribute("name", dir.Name));

            foreach (var file in dir.GetFiles())
            {
                info.Add(new XElement("file",
                             new XAttribute("name", file.Name)));
            }

            foreach (var subDir in dir.GetDirectories())
            {
                info.Add(GetDirectoryXml(subDir));
            }

            return info;
        }
    }
}