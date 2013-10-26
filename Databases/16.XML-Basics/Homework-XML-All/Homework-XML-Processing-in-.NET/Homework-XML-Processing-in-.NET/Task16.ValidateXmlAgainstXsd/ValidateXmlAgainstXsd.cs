/* Using Visual Studio generate an XSD schema for 
 * the file catalog.xml. Write a C# program that 
 * takes an XML file and an XSD file (schema) and
 * validates the XML file against the schema. 
 * Test it with valid XML catalogs and invalid 
 * XML catalogs.
 */

namespace Task16.ValidateXmlAgainstXsd
{
    using System;
    using System.Xml;
    using System.Xml.Schema;

    public class ValidateXmlAgainstXsd
    {
        public static bool success;

        public static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("urn:catalog-shema", "../../Catalog.xsd");

            // Try with Catalog.xml and InvalidCatalog.xml to see result.
            bool isValidationInvalid = Validate("../../InvalidCatalog.xml", schemas);
            //bool isValidationInvalid = Validate("../../Catalog.xml", schemas);

            if (isValidationInvalid)
            {
                Console.WriteLine("File is valid!");
            }
        }

        private static bool Validate(String filename, XmlSchemaSet schemaSet)
        {
            Console.WriteLine("Validating XML file {0}...", filename.ToString());

            XmlSchema compiledSchema = null;

            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                compiledSchema = schema;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            settings.ValidationType = ValidationType.Schema;

            success = true;

            //Create the schema validating reader.
            XmlReader vreader = XmlReader.Create(filename, settings);

            while (vreader.Read()) { }

            //Close the reader.
            vreader.Close();
            return success;
        }

        //Display any warnings or errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            }
            else 
            {
                Console.WriteLine("\tValidation error: " + args.Message);
            }

            success = false;
        }
    }
}
