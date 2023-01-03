using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Interfaces
{
    public interface IRepository<T>
    {
        Task<bool> AddAsync(T entity);

        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
