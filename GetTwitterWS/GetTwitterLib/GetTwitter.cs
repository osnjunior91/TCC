using GetTwitterLib.Infrastructure;
using GetTwitterLib.Infrastructure.Dbs;
using GetTwitterLib.Infrastructure.Twitter;
using GetTwitterLib.Model;
using System;
using System.Collections.Generic;

namespace GetTwitterLib
{
    public class GetTwitter : BaseClass
    {
        public override void Dispose()
        {
            base.Dispose();
        }
        public void GetAllTwitter(string param)
        {
            try
            {
                using (var getTwitter = new ServiceTwitter())
                {
                    var twitter = getTwitter.GetTwitter(param);
                    SavedTwitter(twitter);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SavedTwitter(List<TwitterObject> twitter)
        {
            try
            {
                using (var twitterRepository = new TwitterRepository())
                {
                    foreach (var item in twitter)
                    {
                        if (!twitterRepository.ExistsTwitter(item.id))
                            twitterRepository.SaveTwitter(new TweetedSave(item));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
