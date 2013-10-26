/* Write a program, which extract from the 
 * file catalog.xml the prices for all 
 * albums, published 5 years ago or earlier.
 * Use XPath query.
 */

namespace Task11.GetPriceXPath
{
    using System;
    using System.Xml;

    public class GetPriceXPath
    {
        public static void Main()
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load("../../Catalog.xml");

            string query = "/catalog/album/year[text() > '2008']";

            XmlNodeList albums = catalog.SelectNodes(query);

            foreach (XmlNode album in albums)
            {
                Console.WriteLine("Album: {0} - price: {1}",
                    album.ParentNode.SelectSingleNode("name").InnerText,
                    album.ParentNode.SelectSingleNode("price").InnerText);
            }
        }
    }
}
