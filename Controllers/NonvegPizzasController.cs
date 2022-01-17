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
    public class NonvegPizzasController : ControllerBase
    {
        private readonly PizzeriaContext _context;

        public NonvegPizzasController(PizzeriaContext context)
        {
            _context = context;
        }

        // GET: api/NonvegPizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonvegPizza>>> GetNonvegPizzas()
        {
            return await _context.NonvegPizzas.ToListAsync();
        }

        // GET: api/NonvegPizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NonvegPizza>> GetNonvegPizza(int id)
        {
            var nonvegPizza = await _context.NonvegPizzas.FindAsync(id);

            if (nonvegPizza == null)
            {
                return NotFound();
            }

            return nonvegPizza;
        }

        // PUT: api/NonvegPizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNonvegPizza(int id, NonvegPizza nonvegPizza)
        {
            if (id != nonvegPizza.Nvegid)
            {
                return BadRequest();
            }

            _context.Entry(nonvegPizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonvegPizzaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NonvegPizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NonvegPizza>> PostNonvegPizza(NonvegPizza nonvegPizza)
        {
            _context.NonvegPizzas.Add(nonvegPizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNonvegPizza", new { id = nonvegPizza.Nvegid }, nonvegPizza);
        }

        // DELETE: api/NonvegPizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNonvegPizza(int id)
        {
            var nonvegPizza = await _context.NonvegPizzas.FindAsync(id);
            if (nonvegPizza == null)
            {
                return NotFound();
            }

            _context.NonvegPizzas.Remove(nonvegPizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NonvegPizzaExists(int id)
        {
            return _context.NonvegPizzas.Any(e => e.Nvegid == id);
        }
    }
}
