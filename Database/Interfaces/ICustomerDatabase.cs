using DE_Api.Models;
using System.Collections.Generic;

namespace DE_Api.Database.Interfaces
{
    public interface ICustomerDatabase
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
    }
}
