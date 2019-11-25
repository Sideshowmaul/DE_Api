using DE_Api.Models;
using System.Collections.Generic;

namespace DE_Api.Database.Interfaces
{
    public interface IProductDatabase
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
    }
}
