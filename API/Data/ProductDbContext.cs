
using API.Models;
using API.Models.Enums;
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

            modelBuilder.Entity<Product>().HasData
                (
                
                    new Product()
                    {
                        Id=1,
                        ProductName="Dark Chocolate Bar",
                        Description="A rich and indulgent dark chocolate bar with 70% cooca content",
                        Brand="ChocoDeluxe",
                        Price=3.99f,
                        IngredientsJson=null,
                        Ingredients= new List<string>
                        {
                            "Cocoa mass",
                            "Sugar",
                            "Cocoa butter",
                            "Vanilla extract"
                        },
                        CocoaPercentage=70,
                        Flavor=Flavor.dark,
                        AllergensJson=null,
                        Allergens= null,
                        ImageURlJson=null,
                        ImageURL= new List<string>
                        {
                            "https://images.unsplash.com/photo-1575377427642-087cf684f29d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80",
                            "https://images.unsplash.com/photo-1589552950457-90dd56ef4413?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=715&q=80"
                        },
                        CreatedAt= DateTime.Now,
                        UpdatedAt= DateTime.Now
                    },

                    new Product()
                    {
                        Id = 2,
                        ProductName = "Milk Chocolate Bar",
                        Description = "A creamy and smooth milk chocolate bar with a hint of vanilla",
                        Brand = "SweetDelights",
                        Price = 2.99f,
                        IngredientsJson=null,
                        Ingredients = new List<string>
                        {
                            "Sugar",
                            "Cocoa butter",
                            "Milk powder",
                            "Cocoa mass",
                            "Vanilla extract"
                        },
                        CocoaPercentage = 30,
                        Flavor = Flavor.milk,
                        AllergensJson=null,
                        Allergens = new List<string> { "Milk" },

                        ImageURlJson=null,
                        ImageURL = new List<string>
                        {
                            "https://plus.unsplash.com/premium_photo-1677678736767-7641af9cb43c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80",
                            "https://plus.unsplash.com/premium_photo-1677678736472-3f7498116754?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                        },

                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
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
