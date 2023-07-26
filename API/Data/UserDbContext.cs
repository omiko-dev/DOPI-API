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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_conf.GetConnectionString("UsersDb"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProduct> UserProduct { get; set; }
    }
}
