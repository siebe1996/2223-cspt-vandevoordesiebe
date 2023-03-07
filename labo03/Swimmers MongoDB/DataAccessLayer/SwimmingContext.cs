using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SwimmingContext
    {
        private IMongoDatabase _db;
        private MongoClient _client;

        public SwimmingContext()
        {
            _client = new MongoClient("mongodb://localhost");
            _db = _client.GetDatabase("swimmerMongoDB");
            _db.DropCollection("swimmers");
            _db.DropCollection("workouts");
            _db.DropCollection("swimmingpools");
            _db.DropCollection("coaches");
            _db.DropCollection("members");
        }

        public IMongoCollection<T> GetCollection<T>(string name) 
        { 
            return _db.GetCollection<T>(name);
        }
    }
}
