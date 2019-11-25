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
    public class StoreController : ControllerBase
    {
        private readonly IStoreDatabase _storeDatabase;
        private readonly IStockItemDatabase _stockItemDatabase;

        public StoreController(IStoreDatabase storeDatabase, IStockItemDatabase stockItemDatabase)
        {
            _storeDatabase = storeDatabase;
            _stockItemDatabase = stockItemDatabase;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_storeDatabase.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var store = _storeDatabase.GetById(id);
            if(store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Store store)
        {
            _storeDatabase.Add(store);
            return Ok(store);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Store store)
        {
            var temp = _storeDatabase.GetById(store.Id);
            if(temp == null)
            {
                return NotFound();
            }
            _storeDatabase.Update(store);
            return Ok(store);
        }
    }
}
