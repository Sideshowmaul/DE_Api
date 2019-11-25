using DE_Api.Database.Interfaces;
using DE_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferDatabase _offerDatabase;
        private readonly IProductDatabase _productDatabase;

        public OfferController(IOfferDatabase offerDatabase, IProductDatabase productDatabase)
        {
            _offerDatabase = offerDatabase;
            _productDatabase = productDatabase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_offerDatabase.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var offer = _offerDatabase.GetById(id);
            if (offer == null)
            {
                return NotFound();
            }
            return Ok(offer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Offer offer)
        {
            _offerDatabase.Add(offer);
            return Ok(offer);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Offer offer)
        {
            var temp = _offerDatabase.GetById(offer.Id);
            if (temp == null)
            {
                return NotFound();
            }
            _offerDatabase.Update(offer);
            return Ok(offer);
        }
    }
}
