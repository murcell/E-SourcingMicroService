using ESourcing.Products.Entities;
using ESourcing.Products.Settings;
using MongoDB.Driver;

namespace ESourcing.Products.Data.Interfaces
{
    public class ProductContext : IProductContext
    { 
        public ProductContext(IProductDatabaseSettings productDatabaseSettings)
        {
            var client = new MongoClient(productDatabaseSettings.ConnectionStrings);
            var database = client.GetDatabase(productDatabaseSettings.DatabaseName);
            Products = database.GetCollection<Product>(productDatabaseSettings.ProductCollectionName);

            ProductContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
