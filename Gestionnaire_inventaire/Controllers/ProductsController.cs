using Gestionnaire_inventaire.Data;
using Gestionnaire_inventaire.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Gestionnaire_inventaire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ProductsController(InventoryContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
           var product = await _context.Products.FindAsync(id);
           if(product != null)
            {
             return Ok(product);

            }
            return NotFound();
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product updateProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                return NotFound();
            }
            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.Price= updateProduct.Price;
            product.StockQuantity=updateProduct.StockQuantity;
            product.CategoryId = updateProduct.CategoryId;
            product.SupplierId = updateProduct.SupplierId;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
