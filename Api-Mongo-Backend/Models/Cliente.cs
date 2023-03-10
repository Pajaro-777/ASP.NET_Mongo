using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Api_Mongo_Backend.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("direccion")]
        public string Direccion { get; set; }

        
    }
}
