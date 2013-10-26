using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace _04.SampleConsoleApp
{
    public class MongoHelper<T> where T : class
    {
        public MongoCollection<T> MongoCollection { get; private set; }

        public MongoHelper()
        {
            //const string connectionString = "mongodb://localhost";
            var mongoClient = new MongoClient("mongodb://localhost/");
            MongoServer mongoServer = mongoClient.GetServer();
            //const string databaseName = "retrogamesweb";
            var str = "mongodb://localhost/expenses";
            var dbName = "expenses";
            MongoDatabase db = mongoServer.GetDatabase(dbName);
            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }

        public void InsertData(T value)
        {
            try
            {
                MongoCollection.Save(value);
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }

        public IQueryable<T> LoadData<T>()
        {
            try
            {
                return this.MongoCollection.AsQueryable<T>();
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }

        public void DeleteData<T>(string id)
        {
            try
            {
                var result = this.MongoCollection.Remove(Query.EQ("_id", new ObjectId(id)));
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }

    }
}