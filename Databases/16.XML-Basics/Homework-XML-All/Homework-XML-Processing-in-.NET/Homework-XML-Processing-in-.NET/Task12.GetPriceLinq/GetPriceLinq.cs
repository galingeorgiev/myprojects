/* Write a program, which extract from the 
 * file catalog.xml the prices for all 
 * albums, published 5 years ago or earlier.
 * Use XPath query.
 * 
 * Rewrite the previous using LINQ query.
 */

namespace Task12.GetPriceLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class GetPriceLinq
    {
        public static void Main()
        {
            XDocument catalog = XDocument.Load("../../Catalog.xml");
            var albums = from album in catalog.Descendants("album")
                         where int.Parse(album.Element("year").Value) > 2008
                         select new 
                         {
                             Name = album.Element("name").Value,
                             Price = album.Element("price").Value
                         };

            foreach (var album in albums)
            {
                Console.WriteLine("Album: {0} - price: {1}", album.Name, album.Price);
            }
        }
    }
}
