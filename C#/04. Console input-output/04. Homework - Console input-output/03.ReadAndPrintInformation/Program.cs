using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReadAndPrintInformation
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Please enter company adress: ");
            string companyAdress = Console.ReadLine();

            Console.Write("Please enter company telephone number: ");
            string companyTelNumber = Console.ReadLine();

            Console.Write("Please enter company fax number: ");
            string companyFaxNumber = Console.ReadLine();

            Console.Write("Please enter company web site: ");
            string companyWebSite = Console.ReadLine();

            Console.Write("Please enter company manager name: ");
            string companyManagerName = Console.ReadLine();

            Console.Write("Please enter company manager telephone number: ");
            string managerTelNumber = Console.ReadLine();

            Console.Write("Compani name is {0} it's adress is {1}.\nContacts:\nTelephone number: {2}\nFax number: {3}\nWeb site: {4}\nCompany manager is {5} his telephone number is {6}\n",
                companyName,companyAdress,companyTelNumber,companyFaxNumber,companyWebSite,companyManagerName,managerTelNumber);
        }
    }
}
