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
            Auth.SetUserCredentials("3OKAOOEoPlJ5aQKR3ZII5OQGY",
                    "IdfwEWchz8Mv468pklbb06px08lpDKHYHMEGSKpuLWYjtD1pMa",
                    "296608449-ngjTc7kHu4hZpw5GD4KSwZvLd5mZ1VRecYNkEr9m",
                    "Rn7NeeCWTcL4Ux0dHx4diRGt0o7pHwCsS2Q4gnyz1GOyG");
            var results = TwitterAccessor.GetQueryableJsonObjectFromGETQuery(url).ToString();
            TwitterData twitterData = JsonConvert.DeserializeObject<TwitterData>(results);
            return twitterData.twitterData.FindAll(x => x.retweeted == null);

            /*
             * <add key="CustomerKey" value="3OKAOOEoPlJ5aQKR3ZII5OQGY" />
                <add key="CustomerKeySecret" value="IdfwEWchz8Mv468pklbb06px08lpDKHYHMEGSKpuLWYjtD1pMa" />
                <add key="AcessToken" value="296608449-ngjTc7kHu4hZpw5GD4KSwZvLd5mZ1VRecYNkEr9m" />
                <add key="AcessTokenSecret" value="Rn7NeeCWTcL4Ux0dHx4diRGt0o7pHwCsS2Q4gnyz1GOyG" />
             */
        }

    }
}
