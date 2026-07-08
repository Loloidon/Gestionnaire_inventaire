using System.ComponentModel.DataAnnotations;

namespace Gestionnaire_inventaire.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = "";
        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
