using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Models
{
    public class LoyaltyCard
    {
        public int Id { get; set; }
        public int Discount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public LoyaltyCard()
        {

        }
    }
}
