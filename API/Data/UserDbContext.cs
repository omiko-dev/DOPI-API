using API.Models;
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.Cart)
        //        .WithOne()
        //        .HasForeignKey(p => p.Product_Id);

        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.PurchaseProduct)
        //        .WithOne()
        //        .HasForeignKey(p => p.Product_Id);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(u => u.Cart).WithOne().HasForeignKey(p => p.Product_Id);

            modelBuilder.Entity<User>().HasMany(u => u.PurchaseProduct).WithOne().HasForeignKey(p => p.Product_Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_conf.GetConnectionString("UsersDb"));
        }

        public DbSet<User> Users { get; set; }

    }
}
