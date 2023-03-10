using MongoDB.Bson.Serialization.Attributes;

namespace Api_Mongo_Backend.Models
{
    public class Venta
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("fecha:")]
        public string Fecha { get; set; }
        [BsonElement("iva")]
        public string Iva { get; set; }
        [BsonElement("precio_total")]
        public string Precio_Total { get; set; }
        [BsonElement("cliente")]
        public string Cliente { get; set; }
        [BsonElement("producto")]
        public string Producto {get; set;}
    }
}
