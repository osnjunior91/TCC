using GetTwitterLib.Model;
using MongoDB.Driver;
using System;
using System.Linq;

namespace GetTwitterLib.Infrastructure.Dbs
{
    public class TwitterRepository : BaseClass

    {
        private readonly DBSContext _context = null;
        public TwitterRepository()
        {
            _context = new DBSContext();
        }
        
        public override void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            base.Dispose();
        }

        public void SaveTwitter(TweetedSave twitter)
        {
            try
            {
                _context.Twitter.InsertOneAsync(twitter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ExistsTwitter(string id)
        {
            try
            {
                return _context.Twitter.Find(x => x.id == id).Any();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
