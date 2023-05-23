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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _context;

        public SupplierController(ISupplierService context)
        {
            _context = context;
        }

        // GET: api/Supplier
        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> GetSupplier()
        {
            return _context.GetAll().ToList();
        }

        // GET: api/Supplier/5
        [HttpGet("{id}")]
        public ActionResult<Supplier> GetSupplier(int id)
        {
            var supplier = _context.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // PUT: api/Supplier/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("")]
        public IActionResult PutSupplier(SupplierDto supplier)
        {
            var sup = new Supplier() { Name = supplier.Name };

            _context.Update(sup);

            return Ok();
        }

        // POST: api/Supplier
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Supplier> PostSupplier(SupplierDto supplier)
        {
            var sup = new Supplier() { Name = supplier.Name };
            _context.Insert(sup);
            return CreatedAtAction("GetSupplier", new { id = sup.Id }, supplier);
        }

        // DELETE: api/Supplier/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _context.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Delete(supplier);
            return NoContent();
        }

    }
}
