using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTwitterLib.Model
{
    public class TwitterObject : TweetBase
    {
        [JsonProperty("retweeted_status")]
        public RetweetedData retweeted { get; set; }
    }

    public class TwitterData
    {
        [JsonProperty("statuses")]
        public List<TwitterObject> twitterData { get; set; }
    }

    public class RetweetedData : TweetBase { }
}

public class TweetBase
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    [BsonElement(elementName: "_id")]
    [JsonProperty("id_str")]
    public string id { get; set; }
    [BsonElement(elementName: "texto")]
    [JsonProperty("full_text")]
    public string texto { get; set; }
    [BsonElement(elementName: "dataHora")]
    [JsonProperty("created_at")]
    public string dataHora { get; set; }
    [BsonElement(elementName: "coordinates")]
    [JsonProperty("coordinates")]
    public List<List<Double>> coordinates { get; set; }
}

}
