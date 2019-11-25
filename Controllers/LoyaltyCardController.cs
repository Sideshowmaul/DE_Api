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
    public class LoyaltyCardController : ControllerBase
    {
        private readonly ILoyaltyCardDatabase _loyaltyCardDatabase;
        private readonly ICustomerDatabase _customerDatabase;

        public LoyaltyCardController(ILoyaltyCardDatabase loyaltyCardDatabase, ICustomerDatabase customerDatabase)
        {
            _loyaltyCardDatabase = loyaltyCardDatabase;
            _customerDatabase = customerDatabase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerDatabase.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoyaltyCard card)
        {
            _loyaltyCardDatabase.Add(card);
            return Ok(card);
        }

        [HttpPut]
        public IActionResult Put([FromBody] LoyaltyCard card)
        {
            var temp = _loyaltyCardDatabase.GetById(card.Id);
            if (temp == null)
            {
                return NotFound();
            }
            _loyaltyCardDatabase.Update(card);
            return Ok(card);
        }
    }
}
