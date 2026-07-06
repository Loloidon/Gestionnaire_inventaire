namespace Gestionnaire_inventaire.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
