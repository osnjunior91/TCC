using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetTwitterLib.Infrastructure.Http
{
    public class GeneralHttpClient
    {
        private static HttpClient _client = null;
        public static HttpClient ClientHttp
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                }

                return _client;
            }
        }

        public static async Task<List<T>> GetAsync<T>(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string resultContent = await response.Content.ReadAsStringAsync();
                return await ((response.IsSuccessStatusCode) ?
                    Task.FromResult(JsonConvert.DeserializeObject<List<T>>(resultContent)) :
                    throw new HttpRequestException(resultContent));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static async Task<T> GetUniqueAsync<T>(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string resultContent = await response.Content.ReadAsStringAsync();
                return await ((response.IsSuccessStatusCode) ?
                    Task.FromResult(JsonConvert.DeserializeObject<T>(resultContent)) :
                    throw new HttpRequestException(resultContent));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
