using Gestionnaire_inventaire.Data;
using Gestionnaire_inventaire.Model;
using Gestionnaire_inventaire.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductDto productDto)
        {
            var product = new Product { 
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                CategoryId = productDto.CategoryId,
                SupplierId = productDto.SupplierId,
                CreatedAt = DateTime.Now};
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Category)
                                                 .Include(p => p.Supplier)
                                                 .FirstOrDefaultAsync(p=>p.Id == id);
           if(product == null)
            {
             return NotFound();

            }
             return Ok(product);
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id,ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price= productDto.Price;
            product.StockQuantity=productDto.StockQuantity;
            product.CategoryId = productDto.CategoryId;
            product.SupplierId = productDto.SupplierId;
            

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
