/* A text file phones.txt holds information about people, their town and phone number:
 * 
 * Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
 * Kireto                  | Varna    | 052 23 45 67
 * Daniela Ivanova Petrova | Karnobat | 0899 999 888
 * Bat Gancho              | Sofia    | 02 946 946 946
 * 
 * Duplicates can occur in people names, towns and phone numbers. Write a program to read
 * the phones file and execute a sequence of commands given in the file commands.txt:
 *  - find(name) – display all matching records by given name (first, middle, last or nickname)
 *  - find(name, town) – display all matching records by given name and town
 */

namespace PhoneBook
{
    using System;
    using System.IO;

    public class PhoneBookTest
    {
        public static void Main()
        {
            PhoneBook phoneBook = new PhoneBook();

            string filePath = "../../TextFiles/phones.txt";
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] personElements = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    string personName = personElements[0].Trim();
                    string personTown = personElements[1].Trim();
                    string personPhone = personElements[2].Trim();
                    Person currentPerson = new Person(personName, personTown, personPhone);

                    phoneBook.Add(currentPerson);
                }
            }

            Console.WriteLine("---------- Test Find(string name) ----------");
            phoneBook.Find("Mimi Shmatkata");

            Console.WriteLine("\n---------- Test Find(string name, string town) ----------");
            phoneBook.Find("Mimi Shmatkata", "Sofia");
        }
    }
}
