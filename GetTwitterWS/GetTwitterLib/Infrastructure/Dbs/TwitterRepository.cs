using GetTwitterLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTwitterLib.Infrastructure.Dbs
{
    public class TwitterRepository
    {
        private static DBSContext _context = null;
        public static DBSContext Context {
            get
            {
                if (_context == null)
                {
                    _context = new DBSContext();
                }

                return _context;
            }
        }

        public static async Task SaveTwitter(TwitterObject twitter)
        {
            try
            {
                await _context.Twitter.InsertOneAsync(twitter);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
