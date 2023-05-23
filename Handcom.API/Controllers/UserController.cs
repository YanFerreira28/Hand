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

namespace Handcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _context;

        public UserController(IUserService context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUser()
        {
            return _context.GetAll().ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<Users> GetUsers(int id)
        {
            var users = _context.GetById(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Update(users);

            return Ok();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Users> PostUsers(Users users)
        {
            _context.Insert(users);

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsers(int id)
        {
            var users = _context.GetById(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Delete(users);

            return Ok();
        }

    }
}
