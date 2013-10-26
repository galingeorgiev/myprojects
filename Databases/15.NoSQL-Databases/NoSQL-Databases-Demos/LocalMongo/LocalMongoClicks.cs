using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalMongo
{
    //struct ScreenPoint //- this will cause an exception, because BSON cannot deserialize structs. If you need structs, you have to 'deserialize' them by hand
    class ScreenPoint
    {
        public int X;
        public int Y;

        [BsonConstructor]
        public ScreenPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ")";
        }
    }

    class Click
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public ScreenPoint Location { get; set; }
        public string GeoRegion { get; set; }

        [BsonConstructor]
        public Click(ScreenPoint location, string geoRegion, string name = "noname")
        {
            this.Location = new ScreenPoint(location.X, location.Y);
            this.GeoRegion = geoRegion;
            this.Name = name;
        }

        public override string ToString()
        {
            return "Geo region: " + this.GeoRegion + ", Location: " + this.Location + ", Name: " + this.Name;
        }
    }

    class LocalMongoClicks
    {
        public static readonly Random randGen = new Random();

        public static readonly string[] geoRegions = new string[] { "Africa", "Asia", "Australia", "Europe", "NorthAmerica", "SouthAmerica" };

        static string GetRandomizedRegion()
        {
            return geoRegions[randGen.Next(geoRegions.Length)];
        }

        #region CRUD operations
        static void TrackClicks(MongoCollection storageTarget)
        {
            Console.WriteLine("Start moving the mouse around (random positions will be tracked). To stop tracking, press any key on the keyboard");

            while (!Console.KeyAvailable)
            {
                if (randGen.Next(5000) < 1)
                {
                    var cursorPos = System.Windows.Forms.Cursor.Position;

                    var clickGeoRegion = GetRandomizedRegion();

                    Click clickData = new Click(new ScreenPoint(cursorPos.X, cursorPos.Y), clickGeoRegion);
                    Console.WriteLine("tracked at: " + clickData.Location.X + " " + clickData.Location.Y);

                    storageTarget.Insert(clickData);
                }
            }

            Console.WriteLine("Finished tracking clicks");
            Console.ReadKey();
        }

        static List<Click> ListClicks(MongoCollection clicks, int minX = 0, int maxX = int.MaxValue, int minY = 0, int maxY = int.MaxValue)
        {
            var query = Query.And(Query.GTE("Location.X", minX), Query.GTE("Location.Y", minY), Query.LTE("Location.X", maxX), Query.LTE("Location.X", maxY));

            //This operation risks an exception if the element is not exactly a Click object (e.g. has an added field). To be safe, use BsonDocument as a type
            var filteredClicks = clicks.FindAs<Click>(query);
            int index = 0;

            var listedClicks = new List<Click>();

            foreach (var click in filteredClicks)
            {
                Console.WriteLine(index + ". " + click.ToString());
                index++;
                listedClicks.Add(click);
            }

            return listedClicks;
        }

        static void EditClick(Click click, MongoCollection clicks)
        {
            Console.WriteLine("Enter new click name:");
            string clickName = Console.ReadLine();
            var update = Update.Set("Name", clickName);
            var query = Query.EQ("_id", click.Id);
            clicks.Update(query, update);
        }

        static void DeleteClick(Click click, MongoCollection clicks)
        {
            var query = Query.EQ("_id", click.Id);
            clicks.Remove(query);
        }
        #endregion// .find({"Location.X":{"$gte":"j099rj230rj203r2r23r"}});

        #region User Interface Operations
        private static List<Click> ProcessUserCommand(MongoCollection<BsonDocument> clicks, List<Click> lastListed)
        {
            string loweredInput = Console.ReadLine().ToLower();
            if (loweredInput == "a")
            {
                TrackClicks(clicks);
            }
            if (loweredInput == "b")
            {
                Console.WriteLine("To filter results, enter minX, maxX, minY, maxY on a single line. To skip filter, just press enter");
                string[] filters = Console.ReadLine().Split(' ');
                if (filters.Length != 4)
                {
                    lastListed = ListClicks(clicks);
                }
                else
                {
                    lastListed = ListClicks(clicks,
                        int.Parse(filters[0]), int.Parse(filters[1]),
                        int.Parse(filters[2]), int.Parse(filters[3]));
                }
            }
            if (loweredInput == "c")
            {
                if (lastListed == null)
                {
                    Console.WriteLine("Please List the clicks first (operation B)");
                }
                else
                {
                    Console.WriteLine("Enter index (in last listed) of Click to edit:");
                    int index = int.Parse(Console.ReadLine());
                    EditClick(lastListed[index], clicks);
                }
            }
            if (loweredInput == "d")
            {
                if (lastListed == null)
                {
                    Console.WriteLine("Please List the clicks first (operation B)");
                }
                else
                {
                    Console.WriteLine("Enter index (in last listed) of Click to delete:");
                    int index = int.Parse(Console.ReadLine());
                    DeleteClick(lastListed[index], clicks);
                }
            }
            return lastListed;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("A. Start generating clicks"); //Create
            Console.WriteLine("B. List Clicks"); //Read
            Console.WriteLine("C. Edit a listed Click"); //Update
            Console.WriteLine("D. Remove a listed Click"); //Delete
        }
        #endregion

        /// Entry point
        static void Main(string[] args)
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var clicksDb = mongoServer.GetDatabase("clicksDbTest");

            var clicks = clicksDb.GetCollection("clicks");

            List<Click> lastListed = null;

            while (true)
            {
                PrintMenu();

                lastListed = ProcessUserCommand(clicks, lastListed);
            }
        }
    }
}
