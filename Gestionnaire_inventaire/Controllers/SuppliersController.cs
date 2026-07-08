using Gestionnaire_inventaire.Data;
using Gestionnaire_inventaire.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
namespace Gestionnaire_inventaire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController:ControllerBase
    {

        private readonly InventoryContext _context;

        public SuppliersController(InventoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CreateSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.Suppliers.AddAsync(supplier);
            return Ok(supplier);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if(supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSupplier(int id, Supplier updateSupplier)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }
            supplier.CompanyName = updateSupplier.CompanyName;
            supplier.Email = updateSupplier.Email;
            supplier.Phone = updateSupplier.Phone;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if(supplier != null)
            {
                NotFound();
            }
            _context.Remove(supplier);
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
