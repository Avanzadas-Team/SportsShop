using MongoDB.Bson.Serialization.Attributes;

namespace Server.Models
{
    public class Cart
    {
        [BsonElement("pid")]
        public string ProductId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

    }
}
