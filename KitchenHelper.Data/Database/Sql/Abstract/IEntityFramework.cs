using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Database.Sql.Abstract
{
    public interface IEntityFramework<T, U>
    {
        Task CreateAsync(T entity);

        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetListAsync(U resourceParameters);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> ExistsAsync(int id);

        Task<bool> SaveAsync();
    }
}
