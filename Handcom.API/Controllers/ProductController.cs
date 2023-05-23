using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Handcom.Domain.Entities;
using Handcom.Infra.Data;
using Handcom.Domain.Interfaces.Service;
using Handcom.Domain.Dto;

namespace Handcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _context;

        public ProductController(IProductService context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetProduct()
        {
            return _context.GetAll().ToList();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Products> GetProducts(int id)
        {
            var products = _context.GetById(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("")]
        public IActionResult PutProducts(ProductDto products)
        {
            var product = new Products() { Name = products.Name, CreatedAt = products.CreatedAt, Description = products.Description, CategoryId = products.CategoryId, SupplierId = products.SupplierId };
            _context.Update(product);
            return Ok();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Products> PostProducts(ProductDto products)
        {
            var product = new Products() { Name = products.Name, CreatedAt = products.CreatedAt, Description = products.Description, CategoryId = products.CategoryId, SupplierId = products.SupplierId };

            _context.Insert(product);

            return CreatedAtAction("GetProducts", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProducts(int id)
        {
            var products = _context.GetById(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Delete(products);

            return Ok();
        }

    }
}
