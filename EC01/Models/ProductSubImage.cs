using Microsoft.EntityFrameworkCore;

namespace EC01.Models
{
    //[PrimaryKey(nameof(ProductId), nameof(Img))]
    public class ProductSubImage
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public string Img { get; set; } = string.Empty;
    }
}
