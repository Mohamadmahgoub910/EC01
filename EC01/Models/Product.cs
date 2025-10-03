namespace EC01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public string MainImg { get; set; } = string.Empty;



        // Mapping to Category and Brand
        public int CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
        public int BrandId { get; set; }
        public Brand? Brand { get; set; } = null!;

    }
}
