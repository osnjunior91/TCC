using GetTwitterLib.Model;
using MongoDB.Driver;
using System;
using System.Configuration;

namespace GetTwitterLib.Infrastructure.Dbs
{
    public class DBSContext : BaseClass
    {
        private readonly IMongoDatabase _database = null;

        public override void Dispose()
        {
            base.Dispose();
        }

        public DBSContext()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["ConnectionString"]);
            if (client != null)
                _database = client.GetDatabase(ConfigurationManager.AppSettings["Database"]);
        }
        public IMongoCollection<TweetedSave> Twitter
        {
            get
            {
                return _database.GetCollection<TweetedSave>("TwitterData");
            }
        }
    }
}
