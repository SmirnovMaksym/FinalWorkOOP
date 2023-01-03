using Microsoft.EntityFrameworkCore;
using OnlineShop.EF;
using OnlineShop.Interfaces;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopContext _context;

        public UserRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(User entity)
        {
            if(entity == null)
            {
                return false;
            }
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddProductAsync(int idProduct, int idUser)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == idProduct);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == idUser);
            if (product == null || user == null)
            {
                return false;
            }
            user.BoughtProducts.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(x => x.BoughtProducts).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetBoughtProducts(int id)
        {
            var user = await _context.Users.Include(x => x.BoughtProducts).FirstOrDefaultAsync(x => x.Id == id);
            return user.BoughtProducts;
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name == userName);
        }

        public async Task<bool> IfExistAsync(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == userName);
            if(user == null)
            {
                return false;
            }
            return true;
        }
    }
}
