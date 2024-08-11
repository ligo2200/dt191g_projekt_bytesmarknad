using admin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context) 
        {
            _context = context;
        }

        // GET api products
        [HttpGet]
        public async Task<IActionResult> GetProducts() {
            // check if null
            if(_context.Products == null) {
                return NotFound();
            }

            return Ok(await _context.Products.ToListAsync());
        } 

        // POST api products
        [HttpPost("products/sell/{id}")]
        public async Task<IActionResult> SellProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) 
            {
                return NotFound();
            }

            product.IsSold = true;
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }
    }
}
