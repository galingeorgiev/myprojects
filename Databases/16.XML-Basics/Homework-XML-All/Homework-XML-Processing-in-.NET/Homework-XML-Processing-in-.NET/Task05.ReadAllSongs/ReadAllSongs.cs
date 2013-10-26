/* Write a program, which using XmlReader 
 * extracts all song titles from catalog.xml.
 */

namespace Task05.ReadAllSongs
{
    using System;
    using System.Xml;

    public class ReadAllSongs
    {
        public static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../Catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
