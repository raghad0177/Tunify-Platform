using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;

        public UsersController(IUsers context)
        {
            _users = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Getusers()
        {
            return await _users.GetAllUsers();
        }
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
           return await _users.GetUserById(id);
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
          var updated = await _users.UpdateUser(id, users);
            return Ok(updated);
        }
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            return await _users.CreateUser(users);
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task DeleteUsers(int id)
        {
           await _users.DeleteUser(id);
        }
    }
}
