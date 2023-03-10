using Api_Mongo_Backend.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Api_Mongo_Backend.Services
{
    public class VentaServicios
    {
        private IMongoCollection<Venta> _ventas;

        public VentaServicios(IVentaSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _ventas = database.GetCollection<Venta>(settings.Collection);
        }

        public List<Venta> Get()
        {
            return _ventas.Find(d => true).ToList();
        }

        public Venta Create(Venta venta)
        {
            _ventas.InsertOne(venta);
            return venta;
        }

        public void Update(string id, Venta venta)
        {
            _ventas.ReplaceOne(prod => prod.Id == id, venta);
        }

        public void Delete(string id)
        {
            _ventas.DeleteOne(d => d.Id == id);
        }
    }
}
