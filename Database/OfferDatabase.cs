using DE_Api.Database.Interfaces;
using DE_Api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DE_Api.Database
{
    public class OfferDatabase : IOfferDatabase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<Offer> _offer;
        public OfferDatabase(IConfiguration config)
        {
            _config = config;
            var connString = _config["ConnectionString"];

            var client = new MongoClient(connString);
            var database = client.GetDatabase(_config["Database"]);

            _offer = database.GetCollection<Offer>("Offer");
        }

        public void Add(Offer offer)
        {
            offer.Id = Convert.ToInt32(_offer.Count(new BsonDocument()) + 1);
            _offer.InsertOne(offer);
        }

        public List<Offer> GetAll()
        {
            return _offer.Find(offer => true).ToList();
        }

        public Offer GetById(int id)
        {
            return _offer.Find<Offer>(offer => offer.Id == id).FirstOrDefault();
        }

        public void Update(Offer offer)
        {
            _offer.ReplaceOne(tempOffer => offer.Id == tempOffer.Id, offer);
        }
    }
}
