using GetTwitterLib.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IMongoCollection<Twitter> Twitter
        {
            get
            {
                return _database.GetCollection<Twitter>("NomeTabela");
            }
        }
    }
}
