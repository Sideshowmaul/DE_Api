using DE_Api.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DE_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDatabase _customerDatabase;
        private readonly ILoyaltyCardDatabase _loyaltyCardDatabase;
        private readonly IProductDatabase _productDatabase;

        public CustomerController(ICustomerDatabase customerDatabase, ILoyaltyCardDatabase loyaltyCardDatabase, IProductDatabase productDatabase)
        {
            _customerDatabase = customerDatabase;
            _loyaltyCardDatabase = loyaltyCardDatabase;
            _productDatabase = productDatabase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerDatabase.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerDatabase.GetById(id);
            if(customer == null)
            {
                return NotFound();
            }
            var loyaltyCard = _loyaltyCardDatabase.GetByCustomerId(customer.Id);
            if (loyaltyCard == null)
            {
                return Ok(customer);
            }
            customer.LoyaltyCard = loyaltyCard;
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            _customerDatabase.Add(customer);
            return Ok(customer);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            var temp = _customerDatabase.GetById(customer.Id);
            if(temp == null)
            {
                return NotFound();
            }
            _customerDatabase.Update(customer);
            return Ok(customer);
        }
    }
}
