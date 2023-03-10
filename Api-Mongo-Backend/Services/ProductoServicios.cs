using Api_Mongo_Backend.Models;
using ApiMongo.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Api_Mongo_Backend.Services
{
    public class ProductoServicios
    {
        private IMongoCollection<Producto> _productos;

        public ProductoServicios(IProductoSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _productos = database.GetCollection<Producto>(settings.Collection);
        }

        public List<Producto> Get()
        {
            return _productos.Find(d => true).ToList();
        }

        public Producto Create(Producto prod)
        {
            _productos.InsertOne(prod);
            return prod;
        }

        public void Update(string id, Producto prod)
        {
            _productos.ReplaceOne(prod => prod.Id == id, prod);
        }

        public void Delete(string id)
        {
            _productos.DeleteOne(d => d.Id == id);
        }
    }
}
