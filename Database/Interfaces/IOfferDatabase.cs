using DE_Api.Models;
using System.Collections.Generic;

namespace DE_Api.Database.Interfaces
{
    public interface IOfferDatabase
    {
        List<Offer> GetAll();
        Offer GetById(int id);
        void Add(Offer offer);
        void Update(Offer offer);
    }
}
