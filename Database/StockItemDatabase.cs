using DE_Api.Database.Interfaces;
using DE_Api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DE_Api.Database
{
    public class StockItemDatabase : IStockItemDatabase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<StockItem> _stockItems;

        public StockItemDatabase(IConfiguration config)
        {
            _config = config;
            var connString = _config["ConnectionString"];

            var client = new MongoClient(_config["ConnectionString"]);
            var database = client.GetDatabase(_config["Database"]);

            _stockItems = database.GetCollection<StockItem>("StockItems");
        }

        public void Add(StockItem item)
        {
            item.Id = Convert.ToInt32(_stockItems.Count(new BsonDocument()) + 1);
            _stockItems.InsertOne(item);
        }

        public List<StockItem> GetAll()
        {
            return _stockItems.Find(item => true).ToList();
        }

        public StockItem GetById(int id)
        {
            return _stockItems.Find<StockItem>(stockItem => stockItem.Id == id).FirstOrDefault();
        }

        public List<StockItem> GetByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public List<StockItem> GetByStoreId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StockItem item)
        {
            _stockItems.ReplaceOne(tempItem => item.Id == tempItem.Id, item);
        }
    }
}
