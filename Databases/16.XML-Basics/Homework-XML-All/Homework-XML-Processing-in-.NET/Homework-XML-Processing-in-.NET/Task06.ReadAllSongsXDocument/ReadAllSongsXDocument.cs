/* Write a program, which using XmlReader 
 * extracts all song titles from catalog.xml.
 * 
 * Rewrite the same using XDocument and LINQ query.
 */

namespace Task06.ReadAllSongsXDocument
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ReadAllSongsXDocument
    {
        public static void Main()
        {
            XDocument catalog = XDocument.Load("../../Catalog.xml");
            var songs = from songTitle in catalog.Descendants("title")
                        select songTitle;

            foreach (var title in songs)
            {
                Console.WriteLine(title.Value);
            }
        }
    }
}
