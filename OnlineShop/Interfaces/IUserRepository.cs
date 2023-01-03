using OnlineShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<bool> AddProductAsync(int idProduct, int idUser);

        Task<bool> IfExistAsync(string userName);

        Task<User> GetUserAsync(string userName);

        Task<IEnumerable<Product>> GetBoughtProducts(int id);
    }
}
