using ECommerce.AuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.AuthAPI.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
