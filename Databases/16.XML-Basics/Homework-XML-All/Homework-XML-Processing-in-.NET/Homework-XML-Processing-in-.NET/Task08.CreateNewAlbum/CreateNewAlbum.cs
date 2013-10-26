/* Write a program, which (using XmlReader and XmlWriter) 
 * reads the file catalog.xml and creates the file album.xml,
 * in which stores in appropriate way the names of all albums 
 * and their authors.
 */

namespace Task08.CreateNewAlbum
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    public class CreateNewAlbum
    {
        public static void Main()
        {
            Dictionary<string, List<string>> artistsAndAlbums = new Dictionary<string, List<string>>();
            using (XmlReader reader = XmlReader.Create("../../Catalog.xml"))
            {
                string currentAlbumName = string.Empty;

                while (reader.Read())
                {
                    if (reader.Name == "name")
                    {
                        currentAlbumName = reader.ReadElementString();
                    }
                    else if (reader.Name == "artist")
                    {
                        string currentArtist = reader.ReadElementString();

                        if (artistsAndAlbums.ContainsKey(currentArtist))
                        {
                            artistsAndAlbums[currentArtist].Add(currentAlbumName);
                        }
                        else
                        {
                            artistsAndAlbums.Add(currentArtist, new List<string>() { currentAlbumName });
                        }
                    }
                }
            }

            string fileName = "../../Albums.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                foreach (var artist in artistsAndAlbums)
                {
                    writer.WriteStartElement("artist");
                    writer.WriteElementString("artist-name", artist.Key);

                    writer.WriteStartElement("artist-albums");

                    foreach (var album in artist.Value)
                    {
                        writer.WriteElementString("album-name", album);
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }

            Console.WriteLine("New file is created with name - Albums.xml");
        }
    }
}
