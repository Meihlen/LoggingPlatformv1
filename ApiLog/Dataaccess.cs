using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLog
{
    public class Dataaccess
    {
        public MongoClient client;
        public IMongoDatabase database;
        public IMongoCollection<LogContent> collection;

        public Dataaccess()
        {
            client = new MongoClient("MongoDB connection string");
            database = client.GetDatabase("Logging");
            collection = database.GetCollection<LogContent>("Log");
        }
    }
}
