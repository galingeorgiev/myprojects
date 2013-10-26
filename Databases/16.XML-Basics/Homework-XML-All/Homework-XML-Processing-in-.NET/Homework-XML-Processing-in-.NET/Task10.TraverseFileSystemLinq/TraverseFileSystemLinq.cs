/* Write a program to traverse given directory and write
 * to a XML file its contents together with all subdirectories
 * and files. Use tags <file> and <dir> with appropriate 
 * attributes. For the generation of the XML document use the
 * class XmlWriter.
 * 
 * Rewrite the last exercises using XDocument, XElement and XAttribute.
 */

namespace Task10.TraverseFileSystemLinq
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    class TraverseFileSystemLinq
    {
        public static void Main()
        {
            XElement directories = new XElement("directories");
            DirectoiesTravers("../../", directories);
            Console.WriteLine("New file is created with name - Directoies.xml");
            directories.Save("../../Directoies.xml");
        }

        static void DirectoiesTravers(string startDirectory, XElement directories)
        {
            foreach (string dir in Directory.GetDirectories(startDirectory))
            {
                //writer.WriteStartElement("dir");
                XElement directory = new XElement("dir", new XAttribute("directory-path", dir));
                foreach (string file in Directory.GetFiles(dir))
                {
                    //writer.WriteAttributeString("file", file);
                    directory.Add(new XElement("file", Path.GetFileName(file)));
                }

                DirectoiesTravers(dir, directories);
                directories.Add(directory);
            }
        }
    }
}
