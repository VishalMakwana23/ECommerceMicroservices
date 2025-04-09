using ECommerce.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.OrderAPI.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
    }
}
