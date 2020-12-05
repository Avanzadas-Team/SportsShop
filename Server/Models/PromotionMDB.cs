using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PromotionMDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("nombreDelProd")]
        public string NombreDelProd { get; set; }

        [BsonElement("idProd")]
        public string idProd { get; set; }

        [BsonElement("fechaIn")]
        public DateTime FechaIn { get; set; }

        [BsonElement("fechaFin")]
        public DateTime FechaFin { get; set; }
    }
}
