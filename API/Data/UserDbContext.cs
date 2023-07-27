using API.Models;
using API.Models.dto.UsersDto;
using API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

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

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cart)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 4,
                    Email = "omo",
                    Name = "omiko",
                    PasswordHash = "dada",
                    role = "d",
                    refreshToken = "hjkl",
                    tokenCreate = DateTime.Now,
                    TokenExpires = DateTime.Now.AddDays(1)
                }
            );

            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    ProductName = "Dark Chocolate Bar",
                    Description = "A rich and indulgent dark chocolate bar with 70% cocoa content",
                    Brand = "ChocoDeluxe",
                    Price = 3.99f,
                    IngredientsJson = null,
                    Ingredients = new List<string>
                    {
                        "Cocoa mass",
                        "Sugar",
                        "Cocoa butter",
                        "Vanilla extract"
                    },
                    CocoaPercentage = 70,
                    Flavor = Flavor.dark,
                    AllergensJson = null,
                    Allergens = null,
                    ImageURlJson = null,
                    ImageURL = new List<string>
                    {
            "https://images.unsplash.com/photo-1575377427642-087cf684f29d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80",
            "https://images.unsplash.com/photo-1589552950457-90dd56ef4413?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=715&q=80"
                    },
                    Buy = false,
                    UserId = 4 // This is the foreign key value linking the Cart to the User
                }
            );



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_conf.GetConnectionString("UsersDb"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }
    }
}
