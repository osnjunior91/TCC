using GetTwitterLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.DTO.QueryDTO;
using Tweetinvi.Core.Parameters;
using Tweetinvi.Core.Parameters;

namespace GetTwitterLib.Infrastructure.Twitter
{
    public class ServiceTwitter : IDisposable
    {

        public void Dispose()
        {
        }

        public List<TwitterObject> GetTwitter()
        {
            Auth.SetUserCredentials(ConfigurationManager.AppSettings["CustomerKey"],
                    ConfigurationManager.AppSettings["CustomerKeySecret"],
                    ConfigurationManager.AppSettings["AcessToken"],
                    ConfigurationManager.AppSettings["AcessTokenSecret"]);

            var results = TwitterAccessor.GetQueryableJsonObjectFromGETQuery("https://api.twitter.com/1.1/search/tweets.json?q=bolsonaro&result_type=recent&tweet_mode=extended").ToString();

            TwitterData titterData = JsonConvert.DeserializeObject<TwitterData>(results);

            return null;
        }

    }
}
