namespace Gestionnaire_inventaire.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public ICollection<Product> Products = new List<Product>();
    }
}
