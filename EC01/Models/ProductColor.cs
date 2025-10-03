using Microsoft.EntityFrameworkCore;

namespace EC01.Models
{
    //[PrimaryKey(nameof(ProductId), nameof(Color))]
    public class ProductColor
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public String Color { get; set; } = string.Empty;
    }
}
