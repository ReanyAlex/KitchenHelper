using KitchenHelper.API.Core.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using System.Threading.Tasks;

namespace KitchenHelper.API.Core.Concrete
{
    class Users : IUsers
    {
        private readonly Data.Database.Sql.Abstract.IUsers _dal;

        public Users(Data.Database.Sql.Abstract.IUsers dal)
        {
            _dal = dal ?? throw new System.ArgumentNullException(nameof(dal));
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _dal.GetAsync(userId)
        }
    }
}
