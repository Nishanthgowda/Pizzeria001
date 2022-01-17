#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria001.Models;

namespace Pizzeria001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PizzeriaContext _context;

        public UsersController(PizzeriaContext context)
        {
            _context = context;
        }

        // GET: api/Users


        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUserbyid(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUsers(string email)
        {
            var usersid = from p in _context.Users where p.Email.Equals(email) select p.Usersid;
            int id = usersid.First();

            var account = await _context.Users.FindAsync(id); ;

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { email = user.Email }, user);
        }

       

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Usersid == id);
        }
    }
}
