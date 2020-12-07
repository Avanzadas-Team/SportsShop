using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Cart
    {
        [BsonElement("pname")]
        public string Name { get; set; }

        [BsonElement("pid")]
        public string ProductId { get; set; }
    }
}
