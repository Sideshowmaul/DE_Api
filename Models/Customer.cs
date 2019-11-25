using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLoyal { get; set; }
        public List<Product> Products { get; set; }
        public LoyaltyCard LoyaltyCard { get; set; }
        public Customer()
        {
            Products = new List<Product>();
        }
    }
}
