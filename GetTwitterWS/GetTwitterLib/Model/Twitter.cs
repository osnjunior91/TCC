using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTwitterLib.Model
{
    public class Twitter
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement(elementName: "_id")]
        [JsonProperty("")]
        public string id { get; set; }
        [BsonElement(elementName: "texto")]
        [JsonProperty("")]
        public string texto { get; set; }
        [BsonElement(elementName: "latitude")]
        [JsonProperty("")]
        public double latitude { get; set; }
        [BsonElement(elementName: "longitude")]
        [JsonProperty("")]
        public double longitude { get; set; }
        [BsonElement(elementName: "dataHora")]
        [JsonProperty("")]
        public DateTime dataHora { get; set; }
    }
}
