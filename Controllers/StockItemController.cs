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
    public class StockItemController : ControllerBase
    {
        private readonly IStockItemDatabase _stockItemDatabase;
        private readonly IStoreDatabase _storeDatabase;
        private readonly IProductDatabase _productDatabase;

        public StockItemController(IStockItemDatabase stockItemDatabase, IStoreDatabase storeDatabase, IProductDatabase productDatabase)
        {
            _stockItemDatabase = stockItemDatabase;
            _storeDatabase = storeDatabase;
            _productDatabase = productDatabase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_stockItemDatabase.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var stockItem = _stockItemDatabase.GetById(id);
            if(stockItem == null)
            {
                return NotFound();
            }
            return Ok(stockItem);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StockItem stockItem)
        {
            _stockItemDatabase.Add(stockItem);
            return Ok(stockItem);
        }

        [HttpPut]
        public IActionResult Put([FromBody] StockItem stockItem)
        {
            var temp = _stockItemDatabase.GetById(stockItem.Id);
            if(temp == null)
            {
                return NotFound();
            }
            _stockItemDatabase.Update(stockItem);
            return Ok(stockItem);
        }
    }
}
