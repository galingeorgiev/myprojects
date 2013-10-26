/* Using the DOM parser write a program to delete
 * from catalog.xml all albums having price > 20.
 */

namespace Task04.DeleteFromCatalog
{
    using System;
    using System.Globalization;
    using System.Xml;

    public class DeleteFromCatalog
    {
        public static void Main()
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load("../../Catalog.xml");

            string culture = catalog.DocumentElement.Attributes["culture"].Value;
            CultureInfo numberFormat = new CultureInfo(culture);

            var albums = catalog.DocumentElement.ChildNodes;

            foreach (XmlNode album in albums)
            {
                string currentAlbumPriceFiels = album["price"].InnerText;
                decimal currentAlbumPrice = decimal.Parse(currentAlbumPriceFiels, numberFormat);

                if (currentAlbumPrice > 20m)
                {
                    album.ParentNode.RemoveChild(album);
                }
            }

            catalog.Save("../../NewCatalog.xml");
            Console.WriteLine("Catalog with changes is saved in file: NewCatalog.xml");
        }
    }
}
