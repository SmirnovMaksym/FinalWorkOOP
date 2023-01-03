using Microsoft.EntityFrameworkCore;
using OnlineShop.EF;
using OnlineShop.Interfaces;
using OnlineShop.Models;
using SQLitePCL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
