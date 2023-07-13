
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductDbContext : DbContext
    {
        private readonly IConfiguration _conf;

        public ProductDbContext(DbContextOptions<ProductDbContext> options, IConfiguration conf) : base(options)
        {
            _conf = conf;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Ignore(p => p.Ingredients);
            modelBuilder.Entity<Product>().Ignore(p => p.Allergens);
            modelBuilder.Entity<Product>().Ignore(p => p.ImageURL);

            modelBuilder.Entity<Product>().HasData
                (
                    new Product() 
                    {
                        Product_Id=2,
                        ProductName="Dark Chocolate Bar", 
                        Description="A rich and indulgent dark chocolate bar with 70% cocoa content.",
                        Brand="ChocoDeluxe",
                        Price= 4,
                        Ingredients = new List<string>() { "Cocoa mass", "Sugar", "Cocoa butter", "Vanilla extract" },
                        CocoaPercentage = 70,
                        Flavor = Models.Enums.Flavor.milk,
                        Allergens = new List<string>() { },
                        ImageURL = new List<string>()
                        {
                            "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Green_and_Black%27s_dark_chocolate_bar_2.jpg/280px-Green_and_Black%27s_dark_chocolate_bar_2.jpg",
                            "https://images.unsplash.com/photo-1575377427642-087cf684f29d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                        },
                        CreatedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,

                    }
                );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_conf.GetConnectionString("ProductsDb"));
        }


        public DbSet<Product> products { get; set; }

    }
}
