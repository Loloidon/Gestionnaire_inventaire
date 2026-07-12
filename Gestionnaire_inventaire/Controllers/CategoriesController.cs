using Gestionnaire_inventaire.Data;
using Gestionnaire_inventaire.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestionnaire_inventaire.DTO;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Gestionnaire_inventaire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly InventoryContext _context;
        public CategoriesController(InventoryContext context)
            {
                _context = context;
            }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
            {
                return await _context.Categories.ToListAsync();
            }
        [HttpPost]
        public async Task<ActionResult> CreateCategories(CategoryDto categoryDto)
            {
                var category = new Category 
                {
                    Name = categoryDto.Name,
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategories(int id)
            {
            var category = await _context.Categories.FindAsync(id);
            
            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);

            }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatedCategory(int id, CategoryDto CategoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = CategoryDto.Name;

            await _context.SaveChangesAsync();
            

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category= await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
    
}
