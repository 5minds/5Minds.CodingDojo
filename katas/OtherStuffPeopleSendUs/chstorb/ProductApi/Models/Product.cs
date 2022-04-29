namespace ProductApi.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; } 
    }
}
