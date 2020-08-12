using KitchenHelper.API.Data.Entities.DbEntities;
using System.Threading.Tasks;

namespace KitchenHelper.API.Data.Database.Sql.Abstract
{
    public interface IUsers
    {
        Task<User> GetAsync(int userId);
    }
}
