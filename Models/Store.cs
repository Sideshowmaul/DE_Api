using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StockItem> Inventory { get; set; }
        public Store()
        {
            Inventory = new List<StockItem>();
        }
    }
}
