using MongoDB.Bson.Serialization.Attributes;

namespace Api_Mongo_Backend.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("descripcion")]
        public string Descripcion { get; set; }
        [BsonElement("precio")]
        public string Precio { get; set; }
        [BsonElement("stock")]
        public string stock { get; set; }
    }
}
