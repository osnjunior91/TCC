﻿using MongoDB.Bson.Serialization.Attributes;
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
        [BsonIgnoreIfNull]
        [JsonProperty("retweeted_status")]
        public RetweetedData retweeted { get; set; }
        [JsonProperty("created_at")]
        public string data { get; set; }
    }

    public class TwitterData
    {
        [JsonProperty("statuses")]
        public List<TwitterObject> twitterData { get; set; }
    }

    public class RetweetedData : TweetBase { }
    public class TweetedSave : TweetBase
    {
        public readonly string Const_TwitterDateTemplate = "ddd MMM dd HH:mm:ss +ffff yyyy";
        public TweetedSave(TwitterObject twitter)
        {
            this.id = twitter.id;
            this.texto = twitter.texto;
            this.coordinates = twitter.coordinates;
            this.dataHora = DateTime.ParseExact(twitter.data, Const_TwitterDateTemplate, new System.Globalization.CultureInfo("en-US"));
        }
    }
    public class TweetBase
    {
        [BsonId]
        [BsonElement(elementName: "_id")]
        [JsonProperty("id_str")]
        public string id { get; set; }
        [BsonElement(elementName: "texto")]
        [JsonProperty("full_text")]
        public string texto { get; set; }
        [BsonElement(elementName: "dataHora")]
        public DateTime dataHora { get; set; }
        [BsonElement(elementName: "coordinates")]
        [JsonProperty("coordinates")]
        public List<List<Double>> coordinates { get; set; }
    }

}
