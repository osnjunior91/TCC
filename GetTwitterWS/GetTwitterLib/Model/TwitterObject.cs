using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTwitterLib.Model
{
    public class TwitterObject
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement(elementName: "_id")]
        [JsonProperty("id_str")]
        public string id { get; set; }
        [BsonElement(elementName: "texto")]
        [JsonProperty("text")]
        public string texto { get; set; }
        [BsonElement(elementName: "latitude")]
        [JsonProperty("")]
        public double latitude { get; set; }
        [BsonElement(elementName: "longitude")]
        [JsonProperty("")]
        public double longitude { get; set; }
        [BsonElement(elementName: "dataHora")]
        [JsonProperty("created_at")]
        public DateTime dataHora { get; set; }
    }

    public class TwitterData
    {
        [JsonProperty("statuses")]
        public List<TwitterObject> twitterData { get; set; }
    }
}
