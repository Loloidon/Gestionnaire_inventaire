namespace Gestionnaire_inventaire.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public ICollection<Product> Products = new List<Product>();
    }
}
