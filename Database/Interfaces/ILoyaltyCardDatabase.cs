using DE_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Database.Interfaces
{
    public interface ILoyaltyCardDatabase
    {
        List<LoyaltyCard> GetAll();
        LoyaltyCard GetById(int id);
        LoyaltyCard GetByCustomerId(int id);
        void Add(LoyaltyCard loyaltyCard);
        void Update(LoyaltyCard loyaltyCard);
    }
}
