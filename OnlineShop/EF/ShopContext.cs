using Microsoft.EntityFrameworkCore;
using OnlineShop.Initializer;
using OnlineShop.Models;

namespace OnlineShop.EF
{
    public class ShopContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public ShopContext()
        {
            Database.EnsureCreated();
            ProductInitializer.ProductInitialize(this);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=shop.db");
        }
    }
}
