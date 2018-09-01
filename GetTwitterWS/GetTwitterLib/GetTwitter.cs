using GetTwitterLib.Infrastructure.Http;
using System;
using System.Configuration;

namespace GetTwitterLib
{
    public class GetTwitter : IDisposable
    {
        public void Dispose()
        {
        }

        public void GetAllTwitter()
        {
            using (var httpClient = new GeneralHttpClient())
            {
                var teste = httpClient.GetAsync<object>("search/tweets.json?q=bolsonaro&result_type=popular");
            }

        }
    }
}
