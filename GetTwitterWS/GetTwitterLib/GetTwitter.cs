using GetTwitterLib.Infrastructure;
using GetTwitterLib.Infrastructure.Dbs;
using GetTwitterLib.Infrastructure.Twitter;
using GetTwitterLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GetTwitterLib
{
    public class GetTwitter : BaseClass
    {
        public override void Dispose()
        {
            base.Dispose();
        }
        private void GetAllTwitter(string param)
        {
            try
            {
                using (var getTwitter = new ServiceTwitter())
                {
                    var twitter = getTwitter.GetTwitter(param);
                    SavedTwitter(twitter, param);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetCandidatos()
        {
            try
            {
                using (StreamReader r = new StreamReader("dados.json"))
                {
                    string json = r.ReadToEnd();
                    var candidatos = JsonConvert.DeserializeObject<Candidatos>(json);
                    foreach (var candidato in candidatos.cadidatosData)
                    {
                        foreach (var item in candidato.reference)
                        {
                            GetAllTwitter(item);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SavedTwitter(List<TwitterObject> twitter, string param)
        {
            try
            {
                using (var twitterRepository = new TwitterRepository())
                {
                    foreach (var item in twitter)
                    {
                        if (!twitterRepository.ExistsTwitter(item.id))
                        {
                            item.textoSearch = param;
                            twitterRepository.SaveTwitter(new TweetedSave(item));
                        }
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
