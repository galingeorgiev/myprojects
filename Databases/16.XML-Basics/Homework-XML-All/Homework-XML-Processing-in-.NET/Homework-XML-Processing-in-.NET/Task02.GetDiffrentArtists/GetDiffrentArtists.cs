/* Write program that extracts all different artists 
 * which are found in the catalog.xml. For each author
 * you should print the number of albums in the catalogue.
 * Use the DOM parser and a hash-table.
 */

namespace Task02.GetDiffrentArtists
{
    using System;
    using System.Collections;
    using System.Xml;

    public class GetDiffrentArtists
    {
        public static void Main()
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load("../../Catalog.xml");

            Console.WriteLine(catalog.DocumentElement.ChildNodes);
            var albums = catalog.DocumentElement.ChildNodes;

            Hashtable artists = new Hashtable();

            foreach (XmlNode album in albums)
            {
                var currentArtist = album["artist"].InnerText;

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
