/* Write program that extracts all different artists 
 * which are found in the catalog.xml. For each author
 * you should print the number of albums in the catalogue.
 * Use the DOM parser and a hash-table.
 * 
 * Implement the previous using XPath.
 */

namespace Task03.GetDiffrentArtistsXPath
{
    using System;
    using System.Collections;
    using System.Xml;

    public class GetDiffrentArtistsXPath
    {
        public static void Main()
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load("../../Catalog.xml");
            string query = "/catalog/album/artist";

            XmlNodeList artistsList = catalog.SelectNodes(query);

            Hashtable artists = new Hashtable();

            foreach (XmlNode artist in artistsList)
            {
                var currentArtist = artist.InnerText;

                if (artists[currentArtist] == null)
                {
                    artists[currentArtist] = 1;
                }
                else
                {
                    artists[currentArtist] = int.Parse(artists[currentArtist].ToString()) + 1;
                }
            }

            foreach (DictionaryEntry artist in artists)
            {
                Console.WriteLine("Artist: {0} - {1} album(s)", artist.Key, artist.Value);
            }
        }
    }
}
