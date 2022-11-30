namespace online_medical_services.Models
{
    public class AddProductModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;
        public int Discount { get; set; }
        public DateTime Expiry { get; set; }
        public string Returnable { get; set; } = null!;
        public int Quantity { get; set; }

    }
}
