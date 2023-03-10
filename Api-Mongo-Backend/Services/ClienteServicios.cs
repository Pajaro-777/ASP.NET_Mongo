using Api_Mongo_Backend.Models;
using ApiMongo.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Api_Mongo_Backend.Services
{
    public class ClienteServicios
    {
        IMongoCollection<Cliente> _cliente;

        public ClienteServicios(IClienteSettings settings)
        {
            
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _cliente = database.GetCollection<Cliente>(settings.Collection);
        }

        public List<Cliente> Get()
        {
            return _cliente.Find(d => true).ToList();
        }

        public Cliente Create(Cliente cli)
        {
            _cliente.InsertOne(cli);
            return cli;
        }

        public void Update(string id, Cliente cli)
        {
            _cliente.ReplaceOne(prod => prod.Id == id, cli);
        }

        public void Delete(string id)
        {
            _cliente.DeleteOne(d => d.Id == id);
        }
    }
}
