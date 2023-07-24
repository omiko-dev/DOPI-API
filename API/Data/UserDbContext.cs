using API.Models;
using API.Models.dto.UsersDto;
using API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Data
{
    public class UserDbContext : DbContext
    {
        private readonly IConfiguration _conf;

        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration conf) : base(options)
        {
            _conf = conf;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<User>().HasMany(u => u.Cart).WithOne().HasForeignKey(p => p.Product_Id);

            modelBuilder.Entity<User>().HasMany(u => u.Cart).WithOne().HasForeignKey(p => p.UserId);
            //modelBuilder.Entity<User>().HasMany(u => u.PurchaseProduct).WithOne().HasForeignKey(p => p.Product_Id);

            modelBuilder.Entity<User>().HasMany(u => u.PurchaseProduct).WithOne().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<User>().HasData
                (

                    new User
                    {
                        Id = 1,
                        Email = "Admin0000@gmail.com",
                        Name = "Admin",
                        PasswordHash = "$2a$11$84XRWaZseDIjsr5tznOWtOy.6n0QAphZRl8A798Fd.RzJ/6eJUCe.",
                        role = "admin",
                        refreshToken = "",
                        tokenCreate = DateTime.Now,
                        TokenExpires = DateTime.Now.AddDays(7),
                        Cart = new List<UserProductDto>
                         {
                            new UserProductDto()
                            {
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
                                UserId=1,
                                Product_Id=1,
                                ImageURlJson=null,
                                ImageURL= new List<string>
                                {
                                    "https://images.unsplash.com/photo-1575377427642-087cf684f29d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80",
                                    "https://images.unsplash.com/photo-1589552950457-90dd56ef4413?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=715&q=80"
                                },
                                CreatedAt= DateTime.Now,
                                UpdatedAt= DateTime.Now
                            },
                         },
                        PurchaseProduct = new List<UserProductDto> 
                        {
                            new UserProductDto()
                            {
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
                                UserId=1,
                                Product_Id=1,
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
                        }
                    }

                ) ;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_conf.GetConnectionString("UsersDb"));
        }

        public DbSet<User> Users { get; set; }

        //public DbSet<UserProductDto> UserProducts { get; set; }
    }
}
