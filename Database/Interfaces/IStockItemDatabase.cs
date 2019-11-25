using DE_Api.Models;
using System.Collections.Generic;

namespace DE_Api.Database.Interfaces
{
    public interface IStockItemDatabase
    {
        List<StockItem> GetAll();
        List<StockItem> GetByProductId(int id);
        List<StockItem> GetByStoreId(int id);
        StockItem GetById(int id);
        void Add(StockItem item);
        void Update(StockItem item);
    }
}
