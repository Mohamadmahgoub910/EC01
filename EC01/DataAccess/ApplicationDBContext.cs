using EC01.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EC01.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSubImage> productSubImages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=EAGLE\\SQLEXPRESS;Initial Catalog=EC01DB ;Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ProductColor>().HasKey(pc => new { pc.ProductId, pc.Color });
            //modelBuilder.Entity<ProductSubImage>().HasKey(ps => new { ps.ProductId, ps.Img });
            // بدل ميكبر معايا الكونفجريشن بتاع البروجكت عملنا فولدر اسمه انتتي كونفجريشن وحطينا جواه الكونفجريشن بتاع كل انتتي

            //new ProductColorEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductColor>());
            //new ProductSubImageEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductSubImage>());
            //وابتدي انادي عليه بقا بس بدل مبنادي عل كل كونفجر تايب فيه سطر واحد بناء عل مفهوم الاسمبلي فايل وهو هيبص عل كل الكونفجرز ويعملها لها ابلاي

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductColorEntityTypeConfiguration).Assembly);
        }

    }
}
