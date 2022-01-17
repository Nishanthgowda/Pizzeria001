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
    public class VegPizzasController : ControllerBase
    {
        private readonly PizzeriaContext _context;

        public VegPizzasController(PizzeriaContext context)
        {
            _context = context;
        }

        // GET: api/VegPizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VegPizza>>> GetVegPizzas()
        {
            return await _context.VegPizzas.ToListAsync();
        }

        // GET: api/VegPizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VegPizza>> GetVegPizza(int id)
        {
            var vegPizza = await _context.VegPizzas.FindAsync(id);

            if (vegPizza == null)
            {
                return NotFound();
            }

            return vegPizza;
        }

        // PUT: api/VegPizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVegPizza(int id, VegPizza vegPizza)
        {
            if (id != vegPizza.Vegpizzaid)
            {
                return BadRequest();
            }

            _context.Entry(vegPizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VegPizzaExists(id))
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

        // POST: api/VegPizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VegPizza>> PostVegPizza(VegPizza vegPizza)
        {
            _context.VegPizzas.Add(vegPizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVegPizza", new { id = vegPizza.Vegpizzaid }, vegPizza);
        }

        // DELETE: api/VegPizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVegPizza(int id)
        {
            var vegPizza = await _context.VegPizzas.FindAsync(id);
            if (vegPizza == null)
            {
                return NotFound();
            }

            _context.VegPizzas.Remove(vegPizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VegPizzaExists(int id)
        {
            return _context.VegPizzas.Any(e => e.Vegpizzaid == id);
        }
    }
}
