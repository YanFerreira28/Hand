using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Handcom.Domain.Entities;
using Handcom.Domain.Interfaces.Service;
using Handcom.Domain.Dto;

namespace Handcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _context;

        public CategoryController(ICategoryService context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IList<Category>> GetCategory()
        {
            return _context.GetAll().ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category =  _context.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public IActionResult PutCategory(CategoryDto category)
        {
            var obj = new Category() { Name = category.Name };
            _context.Update(obj);
            return Ok();

        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Category> PostCategory(CategoryDto category)
        {
            var obj = new Category() { Name = category.Name };
            _context.Insert(obj);
            return CreatedAtAction("GetCategory", new { id = obj.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Delete(category);

            return Ok();
        }

    }
}
