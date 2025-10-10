using System.ComponentModel.DataAnnotations;

namespace EC01.Models
{
    public class Category
    {
        public int Id { get; set; }
        //[Required]
        //[MinLength(3)]
        //[MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        //[MaxLength(500)]
        public string? Description { get; set; }
        public bool Status { get; set; }

        // Navigation
        //public List<Product> Products { get; set; }= new List<Product>();

    }
}
