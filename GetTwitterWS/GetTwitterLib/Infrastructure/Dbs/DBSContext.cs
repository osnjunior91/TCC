using GetTwitterLib.Model;
using MongoDB.Driver;

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
            var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
                _database = client.GetDatabase("TCC");
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
