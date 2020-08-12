using System.Collections.Generic;
using System.Threading.Tasks;
using DbEntities = KitchenHelper.API.Data.Entities.DbEntities;
using ResourceParameters = KitchenHelper.API.Data.Entities.ResourceParameters;

namespace KitchenHelper.API.Core.Abstract
{
    public interface IUsersRecipe
    {
        Task AddAsync(DbEntities.UsersRecipe entity);
        Task<DbEntities.Recipe> GetAsync(DbEntities.UsersRecipe entity);
        Task<IEnumerable<DbEntities.Recipe>> GetListAsync(DbEntities.UsersRecipe entity, ResourceParameters.Recipes resourceParameters);
        void RemoveAsync(DbEntities.UsersRecipe entity);
    }
}
