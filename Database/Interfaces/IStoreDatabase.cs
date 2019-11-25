using DE_Api.Models;
using System.Collections.Generic;

namespace DE_Api.Database.Interfaces
{
    public interface IStoreDatabase
    {
        List<Store> GetAll();
        Store GetById(int id);
        void Add(Store store);
        void Update(Store store);
    }
}
