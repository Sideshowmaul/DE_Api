using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryFee { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public Product()
        {

        }
    }
}
