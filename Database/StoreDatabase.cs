using DE_Api.Database.Interfaces;
using DE_Api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DE_Api.Database
{
    public class StoreDatabase : IStoreDatabase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<Store> _store;
        public StoreDatabase(IConfiguration config)
        {
            _config = config;
            var connString = _config["ConnectionString"];

            var client = new MongoClient(_config["ConnectionString"]);
            var database = client.GetDatabase(_config["Database"]);

            _store = database.GetCollection<Store>("Stores");
        }

        public void Add(Store store)
        {
            store.Id = Convert.ToInt32(_store.Count(new BsonDocument()) + 1);
            _store.InsertOne(store);
        }

        public List<Store> GetAll()
        {
            return _store.Find(store => true).ToList();
        }

        public Store GetById(int id)
        {
            return _store.Find<Store>(store => store.Id == id).FirstOrDefault();
        }

        public void Update(Store store)
        {
            _store.ReplaceOne(tempStore => store.Id == tempStore.Id, store);
        }
    }
}
