using DE_Api.Database.Interfaces;
using DE_Api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Database
{
    public class LoyaltyCardDatabase : ILoyaltyCardDatabase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<LoyaltyCard> _cards;
        public LoyaltyCardDatabase(IConfiguration config)
        {
            _config = config;
            var connString = _config["ConnectionString"];

            var client = new MongoClient(connString);
            var database = client.GetDatabase(_config["Database"]);

            _cards = database.GetCollection<LoyaltyCard>("LoyaltyCards");
        }

        public void Add(LoyaltyCard loyaltyCard)
        {
            loyaltyCard.Id = Convert.ToInt32(_cards.Count(new BsonDocument()) + 1);
            _cards.InsertOne(loyaltyCard);
        }

        public List<LoyaltyCard> GetAll()
        {
            return _cards.Find(loyaltyCard => true).ToList();
        }

        public LoyaltyCard GetByCustomerId(int id)
        {
            return _cards.Find<LoyaltyCard>(loyaltyCard => loyaltyCard.CustomerId == id).FirstOrDefault();
        }

        public LoyaltyCard GetById(int id)
        {
            return _cards.Find<LoyaltyCard>(loyaltyCard => loyaltyCard.Id == id).FirstOrDefault();
        }

        public void Update(LoyaltyCard loyaltyCard)
        {
            _cards.ReplaceOne(tempCard => loyaltyCard.Id == tempCard.Id, loyaltyCard);
        }
    }
}
