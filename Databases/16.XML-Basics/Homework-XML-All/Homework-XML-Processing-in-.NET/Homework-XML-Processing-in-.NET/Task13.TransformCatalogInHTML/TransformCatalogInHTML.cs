/* Create an XSL stylesheet, which transforms
 * the file catalog.xml into HTML document, 
 * formatted for viewing in a standard Web-browser.
 */

namespace Task13.TransformCatalogInHTML
{
    using System;
    using System.Xml.Xsl;

    public class TransformCatalogInHTML
    {
        public static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../Catalog.xslt");
            xslt.Transform("../../Catalog.xml", "../../Catalog.html");
            Console.WriteLine("File Catalog.html is created.");
        }
    }
}
