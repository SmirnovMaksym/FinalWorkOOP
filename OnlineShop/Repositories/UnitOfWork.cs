using OnlineShop.EF;
using OnlineShop.Interfaces;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;

        public IRepository<Product> ProductRepository { get; }

        public IUserRepository UserRepository { get; }

        public UnitOfWork(ShopContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            UserRepository = new UserRepository(_context);
        }
    }
}
