using DE_Api.Database.Interfaces;
using DE_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Api.Controllers
{
    // ApiController tells the complier that this class does not return views just JSONs
    [ApiController]
    // This sets the URL route. [controller] gets changed top the name of the class by the complier at run time
    // IE ProductController converts to just product. This is done automatically behind the scenes
    // Just accept it
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductDatabase _productDatabase;
        private readonly IOfferDatabase _offerDatabase;
        public ProductController(IProductDatabase productDatabase, IOfferDatabase offerDatabase)
        {
            _productDatabase = productDatabase;
            _offerDatabase = offerDatabase;
        }

        // HttpGet tells the complier that when the route api/product gets call to just return
        // The list of products
        // IActionResult is for returning HttpStatusCodes
        // Google them as there is a lot of them
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productDatabase.GetAll());
        }


        [HttpGet]
        // This translates into api/[controller]/{id}
        // IE api/product/1
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productDatabase.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            if(product.OfferId > 0)
            {
                var offer = _offerDatabase.GetById(product.OfferId);
                product.Offer = offer;
            }
            return Ok(product);
        }

        // HttpPost is for recieving post calls to the URL api/product
        [HttpPost]
        // FromBody tells the complier that the data is contained in the body of the request
        // Google how Http requests are made
        // There is a header/body of the message
        public IActionResult Post([FromBody]Product product)
        {
            _productDatabase.Add(product);
            return Ok(product);
        }

        // Put is used for Updates
        // Return NotFound by default incase the item you are trying to update does not exist
        // Learn about status codes so you can return the correct ones for whatever happens
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            var temp = _productDatabase.GetById(product.Id);
            if (temp == null)
            {
                return NotFound();
            }
            _productDatabase.Update(product);
            return Ok(product);
        }
    }
}