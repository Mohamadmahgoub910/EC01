using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EC01.DataAccess.EntityConfigurations
{
    public class ProductSubImageEntityTypeConfiguration : IEntityTypeConfiguration<ProductSubImage>
    {
        public void Configure(EntityTypeBuilder<ProductSubImage> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.Img });
        }
    }
}
