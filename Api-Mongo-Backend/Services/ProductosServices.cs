using ApiMongo.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Api_Mongo_Backend.Services
{
    public class ProductosServices
    {
        private IMongoCollection<Productos> _productos;

        public ProductosServices(IBarSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _productos = database.GetCollection<Productos>(settings.Collection);
        }

        public List<Productos> Get()
        {
            return _productos.Find(d => true).ToList();
        }

        public Productos Create(Productos prod)
        {
            _productos.InsertOne(prod);
            return prod;
        }

        public void Update(string id, Productos prod)
        {
            _productos.ReplaceOne(prod => prod.Id == id, prod);
        }

        public void Delete(string id)
        {
            _productos.DeleteOne(d => d.Id == id);
        }
    }
}
