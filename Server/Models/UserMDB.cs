using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class UserMDB : INode
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("lname")]
        public string LName { get; set; }
        [BsonElement("birthdate")]
        public string Birthdate { get; set; }
        [BsonElement("sex")]
        public string Sex { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("cart")]
        public IEnumerable<String> Cart { get; set; }

    }
}
