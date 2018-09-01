using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetTwitterLib.Infrastructure.Http
{
    public class GeneralHttpClient : IDisposable
    {
        public void Dispose()
        {
            if (_client != null)
                _client.Dispose();
        }
        //private HttpClient _client = null;
        private HttpClient _client
        {
            get
            {
                var client = new HttpClient();
                return client;
            }
        }

        public async Task<List<T>> GetAsync<T>(string url)
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

        public async Task<T> GetUniqueAsync<T>(string url)
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
