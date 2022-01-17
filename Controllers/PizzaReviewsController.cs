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
    public class PizzaReviewsController : ControllerBase
    {
        private readonly PizzeriaContext _context;

        public PizzaReviewsController(PizzeriaContext context)
        {
            _context = context;
        }

        // GET: api/PizzaReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaReview>>> GetPizzaReviews()
        {
            return await _context.PizzaReviews.ToListAsync();
        }

        // GET: api/PizzaReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaReview>> GetPizzaReview(int id)
        {
            var pizzaReview = await _context.PizzaReviews.FindAsync(id);

            if (pizzaReview == null)
            {
                return NotFound();
            }

            return pizzaReview;
        }

        // PUT: api/PizzaReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaReview(int id, PizzaReview pizzaReview)
        {
            if (id != pizzaReview.Reviewid)
            {
                return BadRequest();
            }

            _context.Entry(pizzaReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaReviewExists(id))
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

        // POST: api/PizzaReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaReview>> PostPizzaReview(PizzaReview pizzaReview)
        {
            _context.PizzaReviews.Add(pizzaReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizzaReview", new { id = pizzaReview.Reviewid }, pizzaReview);
        }

        // DELETE: api/PizzaReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaReview(int id)
        {
            var pizzaReview = await _context.PizzaReviews.FindAsync(id);
            if (pizzaReview == null)
            {
                return NotFound();
            }

            _context.PizzaReviews.Remove(pizzaReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaReviewExists(int id)
        {
            return _context.PizzaReviews.Any(e => e.Reviewid == id);
        }
    }
}
