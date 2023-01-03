using OnlineShop.Models;

namespace OnlineShop.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        
        IUserRepository UserRepository { get; }
    }
}
