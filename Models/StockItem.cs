using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int StockLevel { get; set; }
        public Store Store { get; set; }
        public Product Product { get; set; }
        public StockItem()
        {

        }
    }
}
