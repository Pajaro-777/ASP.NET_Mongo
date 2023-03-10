using MongoDB.Bson.Serialization.Attributes;

namespace ApiMongo.Models
{
    public class Productos
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Nombre { get; set; }
        [BsonElement("description")]
        public string Descripcion { get; set; }
        [BsonElement("price")]
        public string Precio { get; set; }
        [BsonElement("stock")]
        public string stock { get; set; }
    }
}
