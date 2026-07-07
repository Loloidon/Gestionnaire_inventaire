using Gestionnaire_inventaire.Model;
using Microsoft.EntityFrameworkCore;
namespace Gestionnaire_inventaire.Data

{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) 
        { 

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
    }
}
