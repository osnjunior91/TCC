using GetTwitterLib.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using Tweetinvi;

namespace GetTwitterLib.Infrastructure.Twitter
{
    public class ServiceTwitter : IDisposable
    {
        //private TwitterService Service {
        //    get
        //    {
        //        return new TwitterService(
        //            ConfigurationManager.AppSettings["CustomerKey"],
        //            ConfigurationManager.AppSettings["CustomerKeySecret"],
        //            ConfigurationManager.AppSettings["AcessToken"],
        //            ConfigurationManager.AppSettings["AcessTokenSecret"]);
        //    }
        //}
        public void Dispose()
        {
        }

        public List<TwitterObject> GetTwitter()
        {

            //var twitterResult = Service.Search(new SearchOptions { Q  = "#HaddadPresidente", Resulttype = TwitterSearchResultType.Recent, SinceId = 29999 });
            Auth.SetUserCredentials(ConfigurationManager.AppSettings["CustomerKey"],
                    ConfigurationManager.AppSettings["CustomerKeySecret"],
                    ConfigurationManager.AppSettings["AcessToken"],
                    ConfigurationManager.AppSettings["AcessTokenSecret"]);
            return null;
        }

    }
}
