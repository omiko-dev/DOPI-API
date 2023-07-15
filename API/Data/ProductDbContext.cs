
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_conf.GetConnectionString("ProductsDb"));
        }


        public DbSet<Product> products { get; set; }

    }
}
