using KitchenHelper.API.Data.Database.Sql.Abstract;
using KitchenHelper.API.Data.Entities.DbEntities;
using System;
using System.Threading.Tasks;
namespace KitchenHelper.API.Core.Concrete
{
    public class Users : Abstract.IUsers
    {
        private readonly IUsers _dal;

        public Users(IUsers dal)
        {
            _dal = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _dal.GetAsync(userId);
        }
    }
}
