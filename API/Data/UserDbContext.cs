using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<UserCart>()
                .HasKey(uc => new { uc.UserId, uc.CartId });

            modelBuilder.Entity<UserCart>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserCart)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserCart>()
                .HasOne(c => c.Cart)
                .WithMany(c => c.UserCart)
                .HasForeignKey(c => c.CartId);

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 4,
            //        Email = "omo",
            //        Name = "omiko",
            //        PasswordHash = "dada",
            //        role = "d",
            //        refreshToken = "hjkl",
            //        tokenCreate = DateTime.Now,
            //        TokenExpires = DateTime.Now.AddDays(1)
            //    }
            //);

            //modelBuilder.Entity<Cart>().HasData(
            //    new Cart
            //    {
            //        Id = 1,
            //        ProductName = "Dark Chocolate Bar",
            //        Description = "A rich and indulgent dark chocolate bar with 70% cocoa content",
            //        Brand = "ChocoDeluxe",
            //        Price = 3.99f,
            //        IngredientsJson = null,
            //        Ingredients = new List<string>
            //        {
            //            "Cocoa mass",
            //            "Sugar",
            //            "Cocoa butter",
            //            "Vanilla extract"
            //        },
            //        CocoaPercentage = 70,
            //        Flavor = Flavor.dark,
            //        AllergensJson = null,
            //        Allergens = null,
            //        ImageURlJson = null,
            //        ImageURL = new List<string>
            //        {
            //"https://images.unsplash.com/photo-1575377427642-087cf684f29d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80",
            //"https://images.unsplash.com/photo-1589552950457-90dd56ef4413?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=715&q=80"
            //        },
            //        Buy = false,
            //        UserId = 4 // This is the foreign key value linking the Cart to the User
            //    }
            //);



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_conf.GetConnectionString("UsersDb"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<UserCart> userCarts { get; set; }

        public DbSet<PurchaseProduct> purchaseProducts { get; set; }
    }
}
