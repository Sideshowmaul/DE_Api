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
    public class CustomerDatabase : ICustomerDatabase
    {
        private readonly IConfiguration _config;
        private readonly IMongoCollection<Customer> _customers;

        public CustomerDatabase(IConfiguration configuration)
        {
            _config = configuration;
            var connString = _config["ConnectionString"];

            var client = new MongoClient(_config["ConnectionString"]);
            var database = client.GetDatabase(_config["Database"]);

            _customers = database.GetCollection<Customer>("Customer");
        }
        public void Add(Customer customer)
        {
            customer.Id = Convert.ToInt32(_customers.Count(new BsonDocument()) + 1);
            _customers.InsertOne(customer);
        }

        public List<Customer> GetAll()
        {
            return _customers.Find(customer => true).ToList();
        }

        public Customer GetById(int id)
        {
            return _customers.Find<Customer>(customer => customer.Id == id).FirstOrDefault();
        }

        public void Update(Customer customer)
        {
            _customers.ReplaceOne(tempCustomer => customer.Id == tempCustomer.Id, customer);
        }
    }
}
