using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ProductMDB : INode
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("marca")]
        public string Marca { get; set; }

        [BsonElement("Precio")]
        public float Precio { get; set; }

        [BsonElement("deportes")]
        public IEnumerable<String> Deportes { get; set; }

        [BsonElement("edicionLim")]
        public bool EdicionLim { get; set; }

        [BsonElement("UnDisp")]
        public int UnDisp { get; set; }

        [BsonElement("imagen")]
        public string Imagen { get; set; }

        [BsonElement("tipo")]
        public int Tipo { get; set; }
    }
}
