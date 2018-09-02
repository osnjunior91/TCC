using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTwitterLib.Model
{
    public class Candidatos
    {
        [JsonProperty("candidatos")]
        public List<Candidato> cadidatosData { get; set; }
    }
    public class Candidato
    {
        [JsonProperty("nome")]
        public string nome { get; set; }
        [JsonProperty("partido")]
        public string partido { get; set; }
        [JsonProperty("legenda")]
        public int legenda { get; set; }
        [JsonProperty("reference")]
        public List<string> reference { get; set; }
    }
}
