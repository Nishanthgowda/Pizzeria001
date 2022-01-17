using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Pizzeria001.Models;

namespace Pizzeria001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Transcation : ControllerBase
    {

        public readonly PizzeriaContext _context;

        public Transcation(PizzeriaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        
        [HttpGet("{name}")]
        public async Task<ActionResult<Pizza>> GetPizza(string name)
        {

            var pizzaid = from p in _context.Pizzas where p.Name.Equals(name) select p.Pizzaid;
            int id = pizzaid.First();
            var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }






    }
}
