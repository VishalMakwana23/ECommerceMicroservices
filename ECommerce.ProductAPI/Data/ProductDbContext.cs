using ECommerce.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
