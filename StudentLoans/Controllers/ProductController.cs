using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentLoans.Models;
using StudentLoans.DataAccess;

namespace StudentLoans.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var repo = new ProductRepository();
            var products = repo.GetAllProducts();
            return products;
        }

        [HttpGet("category/{categoryName}")]
        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            var repo = new ProductRepository();
            var products = repo.GetProductsByCategory(categoryName);
            return products;
        }

        [HttpGet("search/{searchTerm}")]
        public IEnumerable<Product> GetProductsByName(string searchTerm)
        {
            var repo = new ProductRepository();
            var products = repo.GetProductsByName(searchTerm);
            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
