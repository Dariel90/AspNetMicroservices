using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configuration;

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings")["ConnectionString"]);
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings")["DatabaseName"]);
            Products = database.GetCollection<Product>(configuration.GetSection("DatabaseSettings")["CollectionName"]);
            //CatalogContextSeed.SeedData(Products)
        }

        public IMongoCollection<Product> Products { get; set; }
    }
}