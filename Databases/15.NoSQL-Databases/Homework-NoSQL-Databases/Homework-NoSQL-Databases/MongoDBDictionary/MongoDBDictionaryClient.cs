/* Write a simple "Dictionary" application in C# or JavaScript to perform the following in MongoDB:
 *  - Add a dictionary entry (word + translation)
 *  - List all words and their translations
 *  - Find the translation of given word
 * The UI of the application is up to you (it could be Web-based, GUI or console-based).
 * You may use MongoDB-as-a-Service@ MongoLab.
 * You may install the "Official MongoDB C# Driver" from NuGet or download it from its publisher:
 * http://docs.mongodb.org/ecosystem/drivers/csharp/
 */

namespace MongoDBDictionary
{
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System;
    using System.Linq;

    public class MongoDBDictionaryClient
    {
        public static void Main()
        {
            var mongoClient = new MongoClient("mongodb://testdbuser:123456@ds057857.mongolab.com:57857/telerikdictionarydb");
            var mongoServer = mongoClient.GetServer();
            var telerikDictionaryDB = mongoServer.GetDatabase("telerikdictionarydb");
            var dictionaryItems = telerikDictionaryDB.GetCollection<DictionaryItem>("DictionaryItems");

            //I use method below to add sample data in MongoDB
            //AddSampleWords(dictionaryItems);

            //var query = Query<DictionaryItem>.EQ(w => w.Word, "2");
            //var translation = dictionaryItems.FindOne(query);

            //Console.WriteLine(translation);

            DrawMenu(dictionaryItems);
        }

        public static void AddSampleWords(MongoCollection<DictionaryItem> dictionaryItems)
        {
            var firstItem = new DictionaryItem { Word = "1", Translation = "One" };
            var secondItem = new DictionaryItem { Word = "2", Translation = "Two" };
            var thirdItem = new DictionaryItem { Word = "3", Translation = "Three" };
            var fourthItem = new DictionaryItem { Word = "4", Translation = "Four" };
            var fifthItem = new DictionaryItem { Word = "5", Translation = "Five" };

            dictionaryItems.Insert(firstItem);
            dictionaryItems.Insert(secondItem);
            dictionaryItems.Insert(thirdItem);
            dictionaryItems.Insert(fourthItem);
            dictionaryItems.Insert(fifthItem);
        }

        public static void DrawMenu(MongoCollection<DictionaryItem> dictionaryItems)
        {
            Console.WriteLine("To list all items type - list");
            Console.WriteLine("To add new word in dictionary type - add");
            Console.WriteLine("To search type - search");
            Console.WriteLine("To exit type - exit");

            string clientChoice = Console.ReadLine();

            switch (clientChoice)
            {
                case "list": 
                    ListItems(dictionaryItems);
                    DrawMenu(dictionaryItems); 
                    break;
                case "add":
                    AddItem(dictionaryItems);
                    DrawMenu(dictionaryItems);
                    break;
                case "search":
                    SearchItem(dictionaryItems);
                    DrawMenu(dictionaryItems);
                    break;
                case "exit": 
                    Console.WriteLine("Bye bye!"); 
                    break;
                default: 
                    Console.WriteLine("Wrong command!");
                    DrawMenu(dictionaryItems);
                    break;
            }
        }

        public static void ListItems(MongoCollection<DictionaryItem> dictionaryItems)
        {
            var allItems = from i in dictionaryItems.AsQueryable<DictionaryItem>()
                           select i;

            foreach (var item in allItems)
            {
                Console.WriteLine(item);
            }
        }

        public static void AddItem(MongoCollection<DictionaryItem> dictionaryItems)
        {
            Console.WriteLine("Enter word: ");
            string word = Console.ReadLine();
            Console.WriteLine("Enter translation: ");
            string translation = Console.ReadLine();

            var newDictionaryItem = new DictionaryItem { Word = word, Translation = translation };
            dictionaryItems.Insert(newDictionaryItem);
            Console.WriteLine("Element added");
        }

        public static void SearchItem(MongoCollection<DictionaryItem> dictionaryItems)
        {
            Console.WriteLine("Enter word for search: ");
            string searchedWord = Console.ReadLine();

            var searchedItems = (from d in dictionaryItems.AsQueryable<DictionaryItem>()
                                where d.Word == searchedWord
                                select d).FirstOrDefault();

            Console.WriteLine(searchedItems);
        }
    }
}
