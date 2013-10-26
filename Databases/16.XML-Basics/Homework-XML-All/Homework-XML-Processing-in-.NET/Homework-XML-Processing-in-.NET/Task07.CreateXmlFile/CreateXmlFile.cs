/* In a text file we are given the name, address and 
 * phone number of given person (each at a single line). 
 * Write a program, which creates new XML document, 
 * which contains these data in structured XML format.
 */

namespace Task07.CreateXmlFile
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class CreateXmlFile
    {
        public static void Main()
        {
            string fileName = "../../Persons.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("persons");
                WritePersons(writer);
                writer.WriteEndElement();

                Console.WriteLine("Document is created with name - Persons.xml");
            }
        }

        public static void WritePersons(XmlWriter writer)
        {
            using (var reader = new StreamReader("../../PersonInformation.txt"))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteStartElement("person");
                    writer.WriteElementString("name", line);
                    line = reader.ReadLine();
                    writer.WriteElementString("adress", line);
                    line = reader.ReadLine();
                    writer.WriteElementString("phone", line);
                    writer.WriteEndElement();
                }
            }
        }
    }
}