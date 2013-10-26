/* Implement the previous task (a simple "Dictionary" application) using Redis.
 * You may hold the "word + meaning pairs" in a hash (see http://redis.io/commands#hash)
 *  - See the HSET, HKEYS and HGET commands
 *  
 * You may use a local Redis instance or register for a free "Redis To Go" 
 * account at https://redistogo.com.
 * 
 * You may download the client libraries for your favorite programming language 
 * from http://redis.io/clients or use the "ServiceStack.Redis" C# client from 
 * the NuGet package manager.
 */

namespace RedisDBDictionary
{
    using ServiceStack.Redis;
    using System;

    class RedisDBDictionaryClient
    {
        private const string ColectionKey = "DictionaryItems";
        static void Main(string[] args)
        {
            // Please start your redis server
            // By default redis use port 6379.
            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
                //I use method below to add sample data in MongoDB
                AddSampleWords(redisClient);
                DrawMenu(redisClient);
            }
        }

        public static void AddSampleWords(RedisClient redisDictionaryClient)
        {
            var firstItem = new DictionaryItem { Word = "1", Translation = "One" };
            var secondItem = new DictionaryItem { Word = "2", Translation = "Two" };
            var thirdItem = new DictionaryItem { Word = "3", Translation = "Three" };
            var fourthItem = new DictionaryItem { Word = "4", Translation = "Four" };
            var fifthItem = new DictionaryItem { Word = "5", Translation = "Five" };

            redisDictionaryClient.HSetNX(ColectionKey, 
                firstItem.Word.ToAsciiCharArray(), firstItem.Translation.ToAsciiCharArray());

            redisDictionaryClient.HSetNX(ColectionKey,
                secondItem.Word.ToAsciiCharArray(), secondItem.Translation.ToAsciiCharArray());

            redisDictionaryClient.HSetNX(ColectionKey,
                thirdItem.Word.ToAsciiCharArray(), thirdItem.Translation.ToAsciiCharArray());

            redisDictionaryClient.HSetNX(ColectionKey,
                fourthItem.Word.ToAsciiCharArray(), fourthItem.Translation.ToAsciiCharArray());

            redisDictionaryClient.HSetNX(ColectionKey,
                fifthItem.Word.ToAsciiCharArray(), fifthItem.Translation.ToAsciiCharArray());
        }

        public static void DrawMenu(RedisClient redisDictionaryClient)
        {
            Console.WriteLine("To list all items type - list");
            Console.WriteLine("To add new word in dictionary type - add");
            Console.WriteLine("To search type - search");
            Console.WriteLine("To exit type - exit");

            string clientChoice = Console.ReadLine();

            switch (clientChoice)
            {
                case "list":
                    ListItems(redisDictionaryClient);
                    DrawMenu(redisDictionaryClient);
                    break;
                case "add":
                    AddItem(redisDictionaryClient);
                    DrawMenu(redisDictionaryClient);
                    break;
                case "search":
                    SearchItem(redisDictionaryClient);
                    DrawMenu(redisDictionaryClient);
                    break;
                case "exit":
                    Console.WriteLine("Bye bye!");
                    break;
                default:
                    Console.WriteLine("Wrong command!");
                    DrawMenu(redisDictionaryClient);
                    break;
            }
        }

        public static void ListItems(RedisClient redisDictionaryClient)
        {
            var allItems = redisDictionaryClient.HGetAll(ColectionKey);

            for (int i = 0; i < allItems.Length; i = i + 2)
            {
                Console.WriteLine("Word: {0} - Translation: {1}",
                    Extensions.StringFromByteArray(allItems[i]), Extensions.StringFromByteArray(allItems[i + 1]));
            }

            Console.WriteLine();
        }

        public static void AddItem(RedisClient redisDictionaryClient)
        {
            Console.WriteLine("Enter word: ");
            string word = Console.ReadLine();
            Console.WriteLine("Enter translation: ");
            string translation = Console.ReadLine();

            var newDictionaryItem = new DictionaryItem { Word = word, Translation = translation };
            redisDictionaryClient.HSetNX(ColectionKey, 
                newDictionaryItem.Word.ToAsciiCharArray(), newDictionaryItem.Translation.ToAsciiCharArray());
            Console.WriteLine("Element added!\n");
        }

        public static void SearchItem(RedisClient redisDictionaryClient)
        {
            Console.WriteLine("Enter word for search: ");
            string searchedWord = Console.ReadLine();

            var searchedItems = redisDictionaryClient.HGet(ColectionKey, searchedWord.ToAsciiCharArray());

            Console.WriteLine("Translation: {0}\n", Extensions.StringFromByteArray(searchedItems));
        }
    }
}
