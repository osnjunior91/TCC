using GetTwitterLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using Tweetinvi;

namespace GetTwitterLib.Infrastructure.Twitter
{
    public class ServiceTwitter : IDisposable
    {

        public void Dispose()
        {
        }

        public List<TwitterObject> GetTwitter(string param)
        {
            string url = $"https://api.twitter.com/1.1/search/tweets.json?q={param}&result_type=recent&tweet_mode=extended&count=100";
            Auth.SetUserCredentials(ConfigurationManager.AppSettings["CustomerKey"],
                    ConfigurationManager.AppSettings["CustomerKeySecret"],
                    ConfigurationManager.AppSettings["AcessToken"],
                    ConfigurationManager.AppSettings["AcessTokenSecret"]);
            var results = TwitterAccessor.GetQueryableJsonObjectFromGETQuery(url).ToString();
            TwitterData twitterData = JsonConvert.DeserializeObject<TwitterData>(results);
            return twitterData.twitterData.FindAll(x => x.retweeted == null);
        }

    }
}
