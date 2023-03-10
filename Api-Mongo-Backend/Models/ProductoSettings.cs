using ApiMongo.Models;

namespace Api_Mongo_Backend.Models
{
    public class ProductoSettings : IProductoSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }

    public interface IProductoSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
