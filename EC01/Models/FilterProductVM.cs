namespace EC01.Models
{
    public record FilterProductVM (string name, decimal? minPrice, decimal? maxPrice, int? categoryId, int? brandId, bool isHot)
    {
    }
}
