using admin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using admin.Models;


namespace admin.Api
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

        // GET: api/Api/products
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {

            // check if null
            if (_context.Products == null)
            {

                return NotFound();
            }

            return Ok(await _context.Products.ToListAsync());
        }

        // GET: api/Api/products/latest
        [HttpGet("products/latest")]
        public async Task<IActionResult> GetLatestProducts()
        {
            // check if null
            if (_context.Products == null)
            {

                return NotFound();
            }
            
            var latestProducts = await _context.Products
            .OrderByDescending(p => p.ProductId)
            .Take(3)
            .ToListAsync();
            

            return Ok(latestProducts);
        }

        // GET: api/Api/categories
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {

            // check if null
            if (_context.Categories == null)
            {

                return NotFound();
            }

            return Ok(await _context.Categories.ToListAsync());
        }

        // GET: api/Api/categories{categoryId}
        [HttpGet("categories/{categoryId}")]
        public async Task<IActionResult> GetCategoriesById(int categoryId)
        {

            // check if null
            if (_context.Categories == null)
            {

                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(p => p.CategoryId == categoryId);

            if (category == null)
            {
                return NotFound();
            }


            return Ok(category);
        }

        // GET: api/Api/products/category/{categoryId}
        [HttpGet("products/category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
    
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            // check if category has products
            if (products == null || products.Count == 0)
            {
                return NotFound($"Inga produkter i denna kategori {categoryId}.");
            }

            return Ok(products);
        }

        // GET: api//Api/products/category/name/{name}
        [HttpGet("products/category/name/{name}")]
        public async Task<IActionResult> GetProductsByCategoryName(string name)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }

            // Hämta produkterna som tillhör den angivna kategorin med namnet.
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category != null && p.Category.Name == name)  // Kontrollera mot kategorinamnet
                .ToListAsync();

            // Kontrollera om några produkter hittades
            if (products == null || products.Count == 0)
            {
                return NotFound($"Inga produkter hittades för kategorin {name}.");
            }

            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        // POST: api/Api/orders
        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
        {
            if (orderRequest == null || orderRequest.ProductIds == null || !orderRequest.ProductIds.Any())
            {
                return BadRequest("Invalid order data.");
            }

            foreach (var productId in orderRequest.ProductIds)
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null || product.IsSold)
                {
                    return BadRequest($"Product with ID {productId} not found or already sold.");
                }

                var sale = new Sale
                {
                    SaleDate = DateTime.Now,
                    SalePrice = product.Price,
                    BuyerName = orderRequest.BuyerName,
                    BuyerAdress = orderRequest.BuyerAdress,
                    ProductId = product.ProductId,
                    SellerId = product.SellerId
                };

                // Markera produkten som såld
                product.IsSold = true;

                _context.Sales.Add(sale);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        public class OrderRequest
        {
            public required string BuyerName { get; set; }
            public required string BuyerAdress { get; set; }
            public List<int> ProductIds { get; set; } = new List<int>();
        }

        // POST: api products
        /*[HttpPost("products/sell/{id}")]
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
        }*/
    }
}
