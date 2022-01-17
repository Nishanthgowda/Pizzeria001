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
    public class OrderPizzasController : ControllerBase
    {
        private readonly PizzeriaContext _context;

        public OrderPizzasController(PizzeriaContext context)
        {
            _context = context;
        }

        // GET: api/OrderPizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderPizza>>> GetOrderPizzas()
        {
            return await _context.OrderPizzas.ToListAsync();
        }

        // GET: api/OrderPizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderPizza>> GetOrderPizza(int id)
        {
            var orderPizza = await _context.OrderPizzas.FindAsync(id);

            if (orderPizza == null)
            {
                return NotFound();
            }

            return orderPizza;
        }

        // PUT: api/OrderPizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderPizza(int id, OrderPizza orderPizza)
        {
            if (id != orderPizza.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderPizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderPizzaExists(id))
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

        // POST: api/OrderPizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderPizza>> PostOrderPizza(OrderPizza orderPizza)
        {
            _context.OrderPizzas.Add(orderPizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderPizza", new { id = orderPizza.OrderId }, orderPizza);
        }

        // DELETE: api/OrderPizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderPizza(int id)
        {
            var orderPizza = await _context.OrderPizzas.FindAsync(id);
            if (orderPizza == null)
            {
                return NotFound();
            }

            _context.OrderPizzas.Remove(orderPizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderPizzaExists(int id)
        {
            return _context.OrderPizzas.Any(e => e.OrderId == id);
        }
    }
}
