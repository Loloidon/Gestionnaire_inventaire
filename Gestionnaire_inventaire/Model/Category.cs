using System.ComponentModel.DataAnnotations;

namespace Gestionnaire_inventaire.Model
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        public ICollection<Product> Products = new List<Product>();
    }
}
