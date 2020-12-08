using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Server.Models
{
    public class PromotionMDB : INode
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("nombreDelProd")]
        public string NombreDelProd { get; set; }

        [BsonElement("idProd")]
        public string IdProd { get; set; }

        [BsonElement("discount")]
        public bool Discount { get; set; }

        [BsonElement("percentage")]
        public string Percentage { get; set; }

        [BsonElement("descr")]
        public string Descrip { get; set; }

        [BsonElement("fechaIn")]
        public string FechaIn { get; set; }

        [BsonElement("fechaFin")]
        public string FechaFin { get; set; }
    }
}
