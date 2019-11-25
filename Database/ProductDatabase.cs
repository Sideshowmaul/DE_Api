using DE_Api.Database.Interfaces;
using DE_Api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DE_Api.Database
{
    public class ProductDatabase : IProductDatabase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<Product> _products;

        public ProductDatabase(IConfiguration config)
        {
            _config = config;
            var connString = _config["ConnectionString"];

            var client = new MongoClient(connString);
            var database = client.GetDatabase(_config["Database"]);

            _products = database.GetCollection<Product>("Products");
        }

        public void Add(Product product)
        {
            product.Id = Convert.ToInt32(_products.Count(new BsonDocument()) + 1);
            _products.InsertOne(product);
        }

        public List<Product> GetAll()
        {
            return _products.Find(product => true).ToList();
        }

        public Product GetById(int id)
        {
            return _products.Find<Product>(product => product.Id == id).FirstOrDefault();
        }

        public void Update(Product product)
        {
            _products.ReplaceOne(tempProduct => product.Id == tempProduct.Id, product);
        }
    }
}
