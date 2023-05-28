using AccountService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccountService.Data.Data
{
    public class AccountAppDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public AccountAppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
    }
}
