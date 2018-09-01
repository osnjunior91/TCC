using GetTwitterLib.Model;
using MongoDB.Driver;

namespace GetTwitterLib.Infrastructure.Dbs
{
    public class DBSContext
    {
        private readonly IMongoDatabase _database = null;
        public DBSContext()
        {
            var client = new MongoClient("Base");
            if (client != null)
                _database = client.GetDatabase("Colection");
        }

        public IMongoCollection<TwitterObject> Twitter
        {
            get
            {
                return _database.GetCollection<TwitterObject>("NomeTabela");
            }
        }
    }
}
